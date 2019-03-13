using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using MKHaberSistemi.Core.Domain.Entities;
using MKHaberSistemi.Service.EtiketService;
using MKHaberSistemi.Service.HaberService;
using MKHaberSistemi.Service.IdentityService;
using MKHaberSistemi.Service.KategoriService;
using MKHaberSistemi.Service.ResimlerService;
using MKHaberSistemi.Utilities.ImageOperations;
using MKHaberSistemi.Utilities.StringOperations;
using MKHaberSistemi.Web.Areas.Admin.Models.HaberModels;
using MKHaberSistemi.Web.Infrastructure.Class;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MKHaberSistemi.Web.Areas.Admin.Controllers
{
   
    public class HaberController : Controller
    {
        static HttpPostedFileBase _resim;
        #region  veri bağlantısı Dependency Injection

        private readonly IHaberService _haberService;
        private readonly IKategoriService _kategoriService;
        private readonly IEtiketService _etiketService;
        private readonly IGaleriService _resimlerService;
        //private readonly IHaberEtiket _haberetiketService;
        private ApplicationUserManager _userManager;
        public HaberController(IHaberService haberService, IKategoriService kategoriService, IEtiketService etiketService, IGaleriService resimlerService, ApplicationUserManager userManager)
        {
            _haberService = haberService;
            _kategoriService = kategoriService;
            _etiketService = etiketService;
            _resimlerService = resimlerService;
            _userManager = userManager;
          
        }

        #endregion

        // GET: Admin/Haber
        public ActionResult Index()
        {
            var haber = _haberService.TumKayitlar().OrderByDescending(x => x.ID);
            return View(haber);
        }

        public ActionResult DenemeView()
        {
            return View();
        }
        public ActionResult Create()
        {
            var model = HaberModelOlustur(new EditHaberViewModel());
            model.IsYayinlandiMi = true;
            return View(model);
        }


       
        [ValidateInput(false)]
        [HttpPost]
        public JsonResult Create(EditHaberViewModel model)
        {

            
            if (ModelState.IsValid)
            {
                var etiketler = _etiketService.TumKayitlar(model.SecilenEtiketId);
                var resimler = _resimlerService.TumKayitlar(model.SecilenResimlerId);



                var image = model.ProfilRsm;
                var fileName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(image.FileName);
                var seoBaslik = StringManager.SeoDuzenleme(model.Baslik);
                var ProfilRsmUrl = Server.MapPath("~/Content/Images/uploads/Haber/" + seoBaslik);
                var ProfilRsmUrlBuyuk = Server.MapPath("~/Content/Images/uploads/Haber/" + seoBaslik + "/Büyük");
                var ProfilRsmUrlOrta = Server.MapPath("~/Content/Images/uploads/Haber/" + seoBaslik + "/Orta");
                var ProfilRsmUrlKucuk = Server.MapPath("~/Content/Images/uploads/Haber/" + seoBaslik + "/Küçük");

                // dizin yoksa oluştur.
                if (!Directory.Exists(ProfilRsmUrl))
                {
                    Directory.CreateDirectory(ProfilRsmUrl);
                    Directory.CreateDirectory(ProfilRsmUrlBuyuk);
                    Directory.CreateDirectory(ProfilRsmUrlOrta);
                    Directory.CreateDirectory(ProfilRsmUrlKucuk);
                }

                // resmi sunucuya kaydet
                image.SaveAs(Path.Combine(ProfilRsmUrl, fileName));

                // resmi küçük boyutta kaydet
                ImageManager.SaveResizedImage(Image.FromFile(Path.Combine(ProfilRsmUrl, fileName)), new Size(150, 150), ProfilRsmUrlKucuk, fileName);
                ImageManager.SaveResizedImage(Image.FromFile(Path.Combine(ProfilRsmUrl, fileName)), new Size(450, 450), ProfilRsmUrlOrta, fileName);
                ImageManager.SaveResizedImage(Image.FromFile(Path.Combine(ProfilRsmUrl, fileName)), new Size(750, 750), ProfilRsmUrlBuyuk, fileName);

                var kullanici = UserManager.FindById(User.Identity.GetUserId());
                var haber = new Haber()
                {
                    Baslik = model.Baslik,
                    SeoBaslik = seoBaslik,
                    Aciklama = model.Aciklama,
                    Icerik = model.Icerik,
                    Kaynak = model.Kaynak,
                    EklemeTarihi = DateTime.Now,
                    GuncellemeTarihi = DateTime.Now,
                    YayinlamaTarihi = DateTime.Now,
                    HaberPozisyonID = model.HaberPozisyonuID,
                    HaberTipID = model.HaberTipiID,
                    KategoriID = model.KategoriID,
                    IsYayinlandiMi = model.IsYayinlandiMi,
                    IsActive = model.IsActive,
                    YorumSayisi = 0,
                    OkumaSayisi = 0,
                    EtiketAdlari = String.Join(",", etiketler.Select(x => x.Ad)),
                    ProfilRsmUrl = Path.Combine("Content/Images/uploads/Haber/" + seoBaslik + "/", fileName),
                    ProfilRsmUrlBuyuk = Path.Combine("Content/Images/uploads/Haber/" + seoBaslik + "/Büyük/", fileName),
                    ProfilRsmUrlOrta = Path.Combine("Content/Images/uploads/Haber/" + seoBaslik + "/Orta/", fileName),
                    ProfilRsmUrlKucuk = Path.Combine("Content/Images/uploads/Haber/" + seoBaslik + "/Küçük/", fileName),
                    YazarId = kullanici.Id,
                    KullaniciID = kullanici.Id,
                    GuncelleyenKullaniciId = kullanici.Id,
                    YayinlayanKullaniciId = kullanici.Id,
                    EkleyenKullaniciId = kullanici.Id
                };

                kullanici.Haberler.Add(haber);
                etiketler.ForEach(x => haber.Etiketler.Add(x));
                resimler.ForEach(x => haber.Galeri.Add(x));

                _haberService.Ekle(haber);
                return Json(new { Success = true, Message = "Haber başarıyla oluşturuldu. " }, JsonRequestBehavior.AllowGet);
            }
            
            model = HaberModelOlustur(model);
           
            var error = ModelState.Select(x => x.Value.Errors).Where(y => y.Count > 0).ToList();
            return Json(new ResultJson { Success = false, Message = "Haber oluşturulamdı. Hata!" });
        }

        public ActionResult Edit(int id)
        {
            var haber = _haberService.BulId(id);          
            var model = new EditHaberViewModel()
            {
                Baslik = haber.Baslik,
                Aciklama = haber.Aciklama,
                Icerik = haber.Icerik,
                Kaynak = haber.Kaynak,
                HaberPozisyonuID = haber.HaberPozisyonID,
                HaberTipiID = haber.HaberTipID,
                KategoriID = haber.KategoriID,
                IsYayinlandiMi = haber.IsYayinlandiMi,
                IsActive = haber.IsActive,
                ProfileResimUrl = haber.ProfilRsmUrl,               
                YazarId = haber.YazarId,
                SecilenEtiketId = haber.Etiketler.Select(e => e.ID).ToArray(),
                SecilenResimlerId = haber.Galeri.Select(r => r.ID).ToArray()              
            };
            model = HaberModelOlustur(model);
            return View(model);
        }

      
        [ValidateInput(false)]
        [HttpPost]
        public JsonResult Edit(EditHaberViewModel model)
        {
            ModelState.Remove("ProfilRsm");          
            if (ModelState.IsValid)
            {
                var haber = _haberService.BulId(model.Id);
                var etiketler = _etiketService.TumKayitlar(model.SecilenEtiketId);
                var resimler = _resimlerService.TumKayitlar(model.SecilenResimlerId);
                var seoBaslik = StringManager.SeoDuzenleme(model.Baslik);
              
                ApplicationUser kullanici = UserManager.FindByEmail(User.Identity.GetUserName());
                
                if (model.ProfilRsm != null)
                {
                    var image = model.ProfilRsm;
                    var fileName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(image.FileName);

                    var ProfilRsmUrl = Server.MapPath("~/Content/Images/uploads/Haber/" + seoBaslik);
                    var ProfilRsmUrlBuyuk = Server.MapPath("~/Content/Images/uploads/Haber/" + seoBaslik + "/Büyük");
                    var ProfilRsmUrlOrta = Server.MapPath("~/Content/Images/uploads/Haber/" + seoBaslik + "/Orta");
                    var ProfilRsmUrlKucuk = Server.MapPath("~/Content/Images/uploads/Haber/" + seoBaslik + "/Küçük");

                    // dizin yoksa oluştur.
                    if (!Directory.Exists(ProfilRsmUrl))
                    {
                        Directory.CreateDirectory(ProfilRsmUrl);
                        Directory.CreateDirectory(ProfilRsmUrlBuyuk);
                        Directory.CreateDirectory(ProfilRsmUrlOrta);
                        Directory.CreateDirectory(ProfilRsmUrlKucuk);
                    }

                    // resmi sunucuya kaydet
                    image.SaveAs(Path.Combine(ProfilRsmUrl, fileName));

                    // resmi küçük boyutta kaydet
                    ImageManager.SaveResizedImage(Image.FromFile(Path.Combine(ProfilRsmUrl, fileName)), new Size(150, 150), ProfilRsmUrlKucuk, fileName);
                    ImageManager.SaveResizedImage(Image.FromFile(Path.Combine(ProfilRsmUrl, fileName)), new Size(450, 450), ProfilRsmUrlOrta, fileName);
                    ImageManager.SaveResizedImage(Image.FromFile(Path.Combine(ProfilRsmUrl, fileName)), new Size(750, 750), ProfilRsmUrlBuyuk, fileName);

                    haber.ProfilRsmUrl = Path.Combine("Content/Images/uploads/Haber/" + seoBaslik + "/", fileName);
                    haber.ProfilRsmUrlBuyuk = Path.Combine("Content/Images/uploads/Haber/" + seoBaslik + "/Büyük/", fileName);
                    haber.ProfilRsmUrlOrta = Path.Combine("Content/Images/uploads/Haber/" + seoBaslik + "/Orta/", fileName);
                    haber.ProfilRsmUrlKucuk = Path.Combine("Content/Images/uploads/Haber/" + seoBaslik + "/Küçük/", fileName);
                }


                haber.Baslik = model.Baslik;
                haber.SeoBaslik = seoBaslik;
                haber.Aciklama = model.Aciklama;
                haber.HaberPozisyonID = model.HaberPozisyonuID;
                haber.HaberTipID = model.HaberTipiID;
                haber.KategoriID = model.KategoriID;
                haber.Kaynak = model.Kaynak;
                haber.Icerik = model.Icerik;
                haber.IsActive = model.IsActive;
                haber.IsYayinlandiMi = model.IsYayinlandiMi;
                haber.GuncellemeTarihi = DateTime.Now;
                haber.GuncelleyenKullaniciId = kullanici.Id;
                haber.EtiketAdlari = String.Join(",", etiketler.Select(e => e.Ad));
                etiketler.ForEach(x => haber.Etiketler.Add(x));
                resimler.ToList().ForEach(x => haber.Galeri.Add(x));
                _haberService.Guncelle(haber);

                return Json(new ResultJson { Success = true, Message = "Haber başarıyla düzenlendi." });
            }

            model = HaberModelOlustur(model);
            var error = ModelState.Select(x => x.Value.Errors).Where(y => y.Count > 0).ToList();
            return Json(new ResultJson { Success = false, Message = "Haber düzenlenemedi. Hata!" });
        }


        public ActionResult Details(DetailHaberViewModel model)
        {
            return View();
        }


        [HttpPost]
        public async Task<JsonResult> Delete(int? id)
        {
            if (id == null)
            {
                return Json(new ResultJson { Success = false });
            }
            await _haberService.SilAsync(id);
            return Json(new ResultJson { Success = true });
        }
        #region Helper
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        private EditHaberViewModel HaberModelOlustur(EditHaberViewModel model)
        {
            model.Kategoriler = _kategoriService.TumKayitlar();
            model.HaberPozisyonlar = _haberService.TumHaberPozisyon();
            model.Resimler = _resimlerService.TumKayitlar();
            model.Etiketler = _etiketService.TumKayitlar();
            model.HaberTipleri = _haberService.TumHaberTip();

            return model;
        }
        #endregion

    }
}