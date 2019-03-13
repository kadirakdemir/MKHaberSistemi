using DevTrends.MvcDonutCaching;
using MKHaberSistemi.Core.Domain.Entities;
using MKHaberSistemi.Data.UnitOfWork;
using MKHaberSistemi.Service.EtiketService;
using MKHaberSistemi.Service.HaberService;
using MKHaberSistemi.Service.KategoriService;
using MKHaberSistemi.Service.ResimlerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI;

namespace MKHaberSistemi.Web.Controllers
{
    
     [RoutePrefix("MKHaber")]
     [Route("{action=Index}")]
    public class HomeController : Controller
    {

        #region veri bağlantısı Dependency Injection

        private readonly IKategoriService _kategoriService;
        private readonly IHaberService _haberService;
        private readonly IEtiketService _etiketService;
        private readonly IGaleriService _galeriService;
        private readonly IUnitOfWork _unitOfWork;
       

        public HomeController(IKategoriService kategoriService, IHaberService haberService, IEtiketService etiketService, IGaleriService galeriService, IUnitOfWork unitOfWork)
        {
            _kategoriService = kategoriService;
            _haberService = haberService;
            _etiketService = etiketService;
            _galeriService = galeriService;
            _unitOfWork = unitOfWork;
        }
        #endregion

        //[DonutOutputCache(Duration = 3600, VaryByParam = "none", Location = OutputCacheLocation.Client)]
        [Route("~/")]
        public ActionResult Index()
        {           
            return View();
        }
        [Route("~/")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult _OrtaSayfaHaber()
        {           
            var haber = _haberService.TumKayitlar(4,2);          
            return PartialView(haber);
        }

        public ActionResult _EnsonOkunanHaberler()
        {
            var haber = _haberService.TumKayitlar(2,2);
            return PartialView(haber);
        }

        public ActionResult _PopulerHaberler()
        {
            var haber = _haberService.TumKayitlar(2,2);
            return PartialView(haber);
        }
        public ActionResult _ResimGaleri()
        {
            var galeri = _galeriService.TumKayitlar();
            return PartialView(galeri);
        }
        //[Route("deneme/{id}")]
        //public ActionResult Git(int id)
        //{
        //    var haber = _haberService.BulId(id);
        //    var haberKategoriAdi = _kategoriService.BulId(haber.KategoriID).Ad;
        //    return RedirectToAction("HaberDetay", new RouteValueDictionary(new { Controller = "Haber", Action = "HaberDetay", id = id,kategoriAdi=haberKategoriAdi,haberBaslik=haber.Baslik }));
        //}

        #region Helper
        //public void Listeler()
        //{
            
        //    //ViewBag.HaberSol = _haberService.TumKayitlar(1, 1);
        //   ViewBag.Orta=_haberService.TumKayitlar();
            
        //    //ViewBag.HaberSag = _haberService.TumKayitlar(3,1);
        //    ViewBag.Kategori = _kategoriService.TumKayitlar();
        //    ViewBag.Etiketler = _etiketService.TumKayitlar();
        //}

        #endregion
    }
}