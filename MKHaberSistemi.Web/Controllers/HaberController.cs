using DevTrends.MvcDonutCaching;
using MKHaberSistemi.Data.UnitOfWork;
using MKHaberSistemi.Service.EtiketService;
using MKHaberSistemi.Service.HaberService;
using MKHaberSistemi.Service.KategoriService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace MKHaberSistemi.Web.Controllers
{
    //[RoutePrefix("HaberDetay")]   
    public class HaberController : Controller
    {

        #region veri bağlantısı Dependency Injection

        private readonly IKategoriService _kategoriService;
        private readonly IHaberService _haberService;
        private readonly IEtiketService _etiketService;
        private readonly IUnitOfWork _unitOfWork;

        public HaberController(IKategoriService kategoriService, IHaberService haberService, IEtiketService etiketService, IUnitOfWork unitOfWork)
        {
            _kategoriService = kategoriService;
            _haberService = haberService;
            _etiketService = etiketService;
            _unitOfWork = unitOfWork;
        }
        #endregion



        [DonutOutputCache(Duration = 3600, VaryByParam = "id", Location = OutputCacheLocation.Client)]
        //[Route("~/{kategoriAdi}/{haberBaslik}/{id=int?}")]
        public ActionResult HaberDetay(int? id)
        {
            if (id==null)
            {
                return HttpNotFound();
            }
            var haber = _haberService.BulId(id);
            haber.OkumaSayisi++;
            _haberService.Guncelle(haber);
            return View(haber);
        }
    }
}