using MKHaberSistemi.Core.Domain.Entities;
using MKHaberSistemi.Service.KategoriService;
using MKHaberSistemi.Utilities.ImageOperations;
using MKHaberSistemi.Utilities.StringOperations;
using MKHaberSistemi.Web.Areas.Admin.Models.KategoriModels;
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
    
    public class KategoriController : Controller
    {
        #region veri bağlantısı Dependency Injection

        private readonly IKategoriService _kategoriService;
       
        public KategoriController(IKategoriService kategoriService)
        {
            _kategoriService = kategoriService;
        }
        #endregion

        // GET: Admin/Kategori
        public ActionResult Index()
        {
            var kategeriler = _kategoriService.TumKayitlar();
            return View(kategeriler.OrderBy(X => X.ID));
        }

        
        public ActionResult Duzenle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var kategori = _kategoriService.BulId(id);
            if (kategori == null)
            {
                return HttpNotFound();
            }

            EditKategoriModel ekm = new EditKategoriModel
            {
                Kategoriler = _kategoriService.TumKayitlar(),
                Ad = kategori.Ad,
                Aciklama = kategori.Aciklama,
                Id = kategori.ID,
                Diger = kategori.Diger,
                AltID = kategori.AltID,
                IsActive = kategori.IsActive,
                ProfileResimUrl = kategori.ProfilResimUrl
            };

            return View(ekm);
        }

        [HttpPost]
        public JsonResult Duzenle(EditKategoriModel model)
        {
            ModelState.Remove("ProfilRsm");
            if (ModelState.IsValid)
            {
                var kategori = _kategoriService.BulId(model.Id);

                if (model.ProfilRsm != null)
                {
                    var image = model.ProfilRsm;
                    var fileName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(image.FileName);
                    var imageDirectory = Server.MapPath("~/Content/Images/uploads/Kategori");
                    var imageDirectorySmall = Server.MapPath("~/Content/Images/uploads/Kategori/Küçük");

                    // dizin yoksa oluştur.
                    if (!Directory.Exists(imageDirectory))
                    {
                        Directory.CreateDirectory(imageDirectory);
                        Directory.CreateDirectory(imageDirectorySmall);
                    }

                    // resmi sunucuya kaydet
                    image.SaveAs(Path.Combine(imageDirectory, fileName));

                    // resmi küçük boyutta kaydet
                    ImageManager.SaveResizedImage(Image.FromFile(Path.Combine(imageDirectory, fileName)), new Size(300, 300), imageDirectorySmall, fileName);
                    kategori.ProfilResimUrl = Path.Combine("Content/Images/uploads/Kategori/Küçük/", fileName);
                }
                kategori.Ad = model.Ad;
                kategori.AltID = model.AltID;
                kategori.Diger = model.Diger;
                kategori.Aciklama = model.Aciklama;
                kategori.IsActive = model.IsActive;
                kategori.DugumYoluIdler = "";
                kategori.DugumYoluMetni = "";
                kategori.SeoAd = StringManager.SeoDuzenleme(model.Ad);
                _kategoriService.Guncelle(kategori);
               
                return Json(new ResultJson { Success = true, Message = "Kayıt başarıyla güncellendi!" });
            }
            model.Kategoriler = _kategoriService.TumKayitlar();
            return Json(new ResultJson { Success = false, Message = "Güncelleme başarısız! Hata-500" });
        }
        public ActionResult Ekle()
        {
            EditKategoriModel ekm = new EditKategoriModel();
            ekm.Kategoriler = _kategoriService.TumKayitlar();
            return View(ekm);
        }


        [HttpPost]
        public JsonResult Ekle(EditKategoriModel model)
        {
            if (ModelState.IsValid)
            {
                var image = model.ProfilRsm;
                var fileName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(image.FileName);
                var imageDirectory = Server.MapPath("~/Content/Images/uploads/Kategori");
                var imageDirectorySmall = Server.MapPath("~/Content/Images/uploads/Kategori/Küçük");

                // dizin yoksa oluştur.
                if (!Directory.Exists(imageDirectory))
                {
                    Directory.CreateDirectory(imageDirectory);
                    Directory.CreateDirectory(imageDirectorySmall);
                }

                // resmi sunucuya kaydet
                image.SaveAs(Path.Combine(imageDirectory, fileName));

                // resmi küçük boyutta kaydet
                ImageManager.SaveResizedImage(Image.FromFile(Path.Combine(imageDirectory, fileName)), new Size(300, 300), imageDirectorySmall, fileName);

                var kategori = new Kategori
                {
                    Aciklama = model.Aciklama,
                    ProfilResimUrl = Path.Combine("Content/Images/uploads/Kategori/Küçük/", fileName),
                    IsActive = model.IsActive,
                    Ad = model.Ad,
                    DugumYoluIdler = "",
                    DugumYoluMetni = "",
                    Diger = model.Diger,
                    AltID = model.AltID,
                    SeoAd = StringManager.SeoDuzenleme(model.Ad)
                };

                _kategoriService.Ekle(kategori);
           
                return Json(new ResultJson { Success = true, Message = "Kategori ekleme işlemi başarıyla gerçekleşti!" });
            }
            model.Kategoriler = _kategoriService.TumKayitlar();
            var error = ModelState.Select(x => x.Value.Errors).Where(y => y.Count > 0).ToList();
            return Json(new ResultJson { Success = false, Message = "Kategori ekleme işlemi başarısız!" });
        }

        public ActionResult Detay(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var kategori = _kategoriService.BulId(id);
            if (kategori == null)
            {
                return HttpNotFound();
            }
            DetayKategoriModel ekm = new DetayKategoriModel
            {
                Kategoriler = _kategoriService.TumKayitlar(),
                Ad = kategori.Ad,
                Aciklama = kategori.Aciklama,
                Id = kategori.ID,
                Diger = kategori.Diger,
                UstKategori = _kategoriService.UstKategoriAdi(id),
                IsActive = kategori.IsActive,
                ProfileResimUrl = kategori.ProfilResimUrl
            };
            return View(ekm);
        }
        [HttpPost]
        public JsonResult Sil(int? id)
        {
            if (id == null)
            {
                return Json(new ResultJson { Success = false });
            }
            _kategoriService.Sil(id);
           
            return Json(new ResultJson { Success = true });
        }


    }
}