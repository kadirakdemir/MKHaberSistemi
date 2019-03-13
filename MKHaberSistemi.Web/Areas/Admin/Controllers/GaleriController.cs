using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using MKHaberSistemi.Core.Domain.Entities;
using MKHaberSistemi.Service.IdentityService;
using MKHaberSistemi.Service.ResimlerService;
using MKHaberSistemi.Utilities.ImageOperations;
using MKHaberSistemi.Utilities.StringOperations;
using MKHaberSistemi.Web.Areas.Admin.Models.GaleriModels;
using MKHaberSistemi.Web.Infrastructure.Class;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MKHaberSistemi.Web.Areas.Admin.Controllers
{
    //[RouteArea("Admin")]
    //[RoutePrefix("galeri")]
    public class GaleriController : Controller
    {

        #region  veri bağlantısı Dependency Injection
        private readonly IGaleriService _galeriService;

        public GaleriController(IGaleriService galeriService)
        {
            _galeriService = galeriService;
        }
        #endregion

        //[Route("index")]
        // GET: Admin/REsimler
        public ActionResult Index()
        {
            var galeriler = _galeriService.TumKayitlar().OrderByDescending(x => x.ID);
            return View(galeriler);
        }

        public ActionResult GaleriEkle()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GaleriEkle(EditGaleriViewModel model)
        {
            if (ModelState.IsValid)
            {
                var resim = model.ProfilRsm;
                var dosyaAdi = Guid.NewGuid().ToString() + Path.GetExtension(resim.FileName);
                var resimDizini = Server.MapPath("~/Content/Images/uploads/Galeri");
                var resimDiziniKucuk = Server.MapPath("~/Content/Images/uploads/Galeri/Kucuk");

                // Dizin yoksa oluştur
                if (!Directory.Exists(resimDizini))
                {
                    Directory.CreateDirectory(resimDizini);
                    Directory.CreateDirectory(resimDiziniKucuk);
                }

                // Resmi sunucuya kaydet
                resim.SaveAs(Path.Combine(resimDizini, dosyaAdi));

                // Resmi kucuk boyut kaydet
                ImageManager.SaveResizedImage(Image.FromFile(Path.Combine(resimDizini, dosyaAdi)), new Size(300, 300), resimDiziniKucuk, dosyaAdi);

                var galeri = new Galeri()
                {
                    Ad = model.Ad,
                    Aciklama = model.Aciklama,
                    EklemeTarihi = DateTime.Now,
                    EkleyenKullaniciId = User.Identity.GetUserId(),
                    SeoAd = StringManager.SeoDuzenleme(model.Ad),
                    IsActive = model.IsActive,
                    ProfilResimUrl = Path.Combine("Content/Images/uploads/Galeri/Kucuk/" + dosyaAdi)
                };
                _galeriService.Ekle(galeri);
                return Json(new ResultJson { Success = true, Message = "Galeri başarıyla oluşturuldu." });
            }
            return Json(new ResultJson { Success = false, Message = "Galeri oluşturulamadı. Hata!" });
        }

        //[Route("~/GaleriDüzenle/{id=int?}")]
        public ActionResult GaleriDuzenle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var kategori = _galeriService.BulId(id);

            if (kategori == null)
            {
                return HttpNotFound();
            }
            var model = new EditGaleriViewModel()
            {
                Id = kategori.ID,
                Ad = kategori.Ad,
                Aciklama = kategori.Aciklama,
                IsActive = kategori.IsActive,
                ProfileResimUrl = kategori.ProfilResimUrl
            };
            return View(model);
        }

        [HttpPost]
        public JsonResult GaleriDuzenle(EditGaleriViewModel model)
        {
            ModelState.Remove("ProfileImg");
            if (ModelState.IsValid)
            {
                var galeri = _galeriService.BulId(model.Id);

                if (model.ProfilRsm != null)
                {
                    var resim = model.ProfilRsm;
                    var dosyaAdi = Guid.NewGuid().ToString() + Path.GetExtension(resim.FileName);
                    var resimDizini = Server.MapPath("~/Content/Images/uploads/Galeri");
                    var resimDiziniKucuk = Server.MapPath("~/Content/Images/uploads/Galeri/Kucuk");

                    // Dizin yoksa oluştur
                    if (!Directory.Exists(resimDizini))
                    {
                        Directory.CreateDirectory(resimDizini);
                        Directory.CreateDirectory(resimDiziniKucuk);
                    }

                    // Resmi sunucuya kaydet
                    resim.SaveAs(Path.Combine(resimDizini, dosyaAdi));

                    // Resmi kucuk boyut kaydet
                    ImageManager.SaveResizedImage(Image.FromFile(Path.Combine(resimDizini, dosyaAdi)), new Size(300, 300), resimDiziniKucuk, dosyaAdi);
                    galeri.ProfilResimUrl = Path.Combine("Content/Images/uploads/Galeri/Kucuk/" + dosyaAdi);
                }

                galeri.Ad = model.Ad;
                galeri.Aciklama = model.Aciklama;
                galeri.GuncellemeTarihi = DateTime.Now;
                galeri.GuncelleyenKullaniciId = User.Identity.GetUserId();
                galeri.SeoAd = StringManager.SeoDuzenleme(model.Ad);
                galeri.IsActive = model.IsActive;

                _galeriService.Guncelle(galeri);
                return Json(new ResultJson { Success = true, Message = "Galeri başarıyla düzenlendi." });
            }
            return Json(new ResultJson { Success = false, Message = "Galeri düzenlenemedi. Hata!" });
        }

        [HttpPost]
        public JsonResult GaleriSil(int? id)
        {
            if (id == null)
            {
                return Json(new ResultJson { Success = false });
            }
            _galeriService.Sil(id);

            return Json(new ResultJson { Success = true });
        }

        //[Route("~/{ad}/{id=int?}",Name ="GaleriResimler")]int id, string ad
        public ActionResult GaleriResimler(int id,string ad)
        {
            var resimler = _galeriService.GetResimler(id);
            ViewBag.GaleriId = id;
            ViewBag.GaleriAdi = ad;           
            return View(resimler);
        }
        public JsonResult GaleriResimlerEkle(int id,string ad)
        {
            //bool IsSavedSuccessfully = true;

           
            try
            {
                foreach (string fileName in Request.Files)
                {
                    var resim = Request.Files[fileName];
                   
                    if (resim!=null&&resim.ContentLength>0)
                    {
                        var seoGaleriAd = StringManager.SeoDuzenleme(ad);
                        var dosyaAdi = Guid.NewGuid().ToString() + Path.GetExtension(resim.FileName);
                        var ProfilRsmUrl = Server.MapPath("~/Content/Images/uploads/Galeri/" + seoGaleriAd);
                        var ProfilRsmUrlBuyuk = Server.MapPath("~/Content/Images/uploads/Galeri/" + seoGaleriAd + "/Büyük");
                        var ProfilRsmUrlOrta = Server.MapPath("~/Content/Images/uploads/Galeri/" + seoGaleriAd + "/Orta");
                        var ProfilRsmUrlKucuk = Server.MapPath("~/Content/Images/uploads/Galeri/" + seoGaleriAd + "/Küçük");

                        // dizin yoksa oluştur.
                        if (!Directory.Exists(ProfilRsmUrl))
                        {
                            Directory.CreateDirectory(ProfilRsmUrl);
                            Directory.CreateDirectory(ProfilRsmUrlBuyuk);
                            Directory.CreateDirectory(ProfilRsmUrlOrta);
                            Directory.CreateDirectory(ProfilRsmUrlKucuk);
                        }

                        // resmi sunucuya kaydet
                        resim.SaveAs(Path.Combine(ProfilRsmUrl, dosyaAdi));

                        // resmi küçük boyutta kaydet
                        ImageManager.SaveResizedImage(Image.FromFile(Path.Combine(ProfilRsmUrl, dosyaAdi)), new Size(150, 150), ProfilRsmUrlKucuk, dosyaAdi);
                        ImageManager.SaveResizedImage(Image.FromFile(Path.Combine(ProfilRsmUrl, dosyaAdi)), new Size(450, 450), ProfilRsmUrlOrta, dosyaAdi);
                        ImageManager.SaveResizedImage(Image.FromFile(Path.Combine(ProfilRsmUrl, dosyaAdi)), new Size(750, 750), ProfilRsmUrlBuyuk, dosyaAdi);

                        var galeriResim = new Resim()
                        {
                            Aciklama = "",
                            Ad=dosyaAdi,
                            EklemeTarihi=DateTime.Now,
                            IsActive=true,
                            EkleyenKullaniciId=User.Identity.GetUserId(),
                            IcerikTipi=resim.ContentType,
                            GaleriID=id,
                            IcerikUzunlugu=resim.ContentLength,
                            RsmUrlOrjinal=Path.Combine("Content/Images/uploads/Galeri/" + seoGaleriAd + "/" + dosyaAdi),
                            RsmUrlBuyuk= Path.Combine("Content/Images/uploads/Galeri/" + seoGaleriAd + "/Büyük/" + dosyaAdi),
                            RsmUrlOrta = Path.Combine("Content/Images/uploads/Galeri/" + seoGaleriAd + "/Orta/" + dosyaAdi),
                            RsmKucuk = Path.Combine("Content/Images/uploads/Galeri/" + seoGaleriAd + "/Çüçük/" + dosyaAdi),
                            
                        };
                        _galeriService.EkleGaleriResim(galeriResim);
                    }
                }
            }
            catch (Exception)
            {

                Json(new ResultJson { Success=false,Message="Yükleme başarısız."});
            }
            return Json(new ResultJson { Message = "Resimler başarıyla yüklendi.", Success = true });
        }

        public JsonResult GaleriResimlerGetir(int? galeriId)
        {
            var resimler = _galeriService.GetResimler(galeriId);
            return Json(new { Result=resimler.ToList()},JsonRequestBehavior.AllowGet);
        }

        #region Helper

        public void Listeler()
        {

        }
        #endregion
    }
}

