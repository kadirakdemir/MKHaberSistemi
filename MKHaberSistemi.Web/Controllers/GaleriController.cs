using DevTrends.MvcDonutCaching;
using MKHaberSistemi.Service.ResimlerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace MKHaberSistemi.Web.Controllers
{
    //[RoutePrefix("Galeri")]
    //[Route("{action=GaleriDetail}")]
    public class GaleriController : Controller
    {
        #region
        private readonly IGaleriService _galeriService;
        public GaleriController(IGaleriService galeriService)
        {
            _galeriService = galeriService;
        }
        #endregion

        //[Route("~/Galeri/{galeriAdi}/{galeriId=int?}", Name = "Resimler")]
        [DonutOutputCache(Duration = 3600, VaryByParam = "id", Location = OutputCacheLocation.Client)]
        // GET: Galeri
        public ActionResult GaleriDetail(int galeriId,string galeriAdi)
        {
            var galeri = _galeriService.GetResimler(galeriId);
            return View(galeri);
        }
    }
}