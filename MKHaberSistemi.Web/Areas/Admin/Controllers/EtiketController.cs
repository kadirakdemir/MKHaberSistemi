using MKHaberSistemi.Core.Domain.Entities;
using MKHaberSistemi.Service.EtiketService;
using MKHaberSistemi.Utilities.StringOperations;
using MKHaberSistemi.Web.Areas.Admin.Models;
using MKHaberSistemi.Web.Infrastructure.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MKHaberSistemi.Web.Areas.Admin.Controllers
{
    
    public class EtiketController : Controller
    {

        #region veri bağlantısı Dependency Injection

        private readonly IEtiketService _etiketService;
        public EtiketController(IEtiketService etiketService)
        {
            _etiketService = etiketService;
        }
        #endregion

        // GET: Admin/Etiket
        public ActionResult Index()
        {
            var etiket = _etiketService.TumKayitlar();
            return View(etiket.OrderBy(x=>x.ID));
        }

        public async Task<ActionResult> Create()
        {
            var etiketler = new EditEtiketViewModel();
            etiketler.Etiketler = await _etiketService.TumKayitlarAsync();
            return View(etiketler);
        }

        [HttpPost]
        public async Task<JsonResult> Create(EditEtiketViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _etiketService.IsValid(model.Ad);
                if (result)
                {
                    var etiket = new Etiket
                    {
                        Ad = model.Ad,
                        Aciklama = model.Aciklama,
                        EklemeTarihi = DateTime.Now,
                        GuncellemeTarihi = DateTime.Now,
                        IsActive = model.IsActive,
                        SeoAd = StringManager.SeoDuzenleme(model.Ad)
                    };
                    await _etiketService.EkleAsync(etiket);
                    return Json(new ResultJson { Success = true, Message = "Etiket ekleme işlemi başarıyla gerçekleşti!" });
                }
                return Json(new ResultJson { Success = false, Message = "Etiket ekleme işlemi başarısız! Aynı isminde daha önce oluşturulmuş etiket var." });
            }
            return Json(new ResultJson { Success = false, Message = "Etiket ekleme işlemi başarısız!" });
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var etiket = await _etiketService.BulIdAsync(id);
            if (etiket == null)
            {
                return HttpNotFound();
            }
            EditEtiketViewModel etiketViewModel = new EditEtiketViewModel();
            etiketViewModel.Ad = etiket.Ad;
            etiketViewModel.Aciklama = etiket.Aciklama;
            etiketViewModel.IsActive = etiket.IsActive;
            return View(etiketViewModel);
        }

        [HttpPost]
        public async Task<JsonResult> Edit(EditEtiketViewModel model)
        {
            if (ModelState.IsValid)
            {
                var etiket = await _etiketService.BulIdAsync(model.Id);
                etiket.Ad = model.Ad;
                etiket.Aciklama = model.Aciklama;
                etiket.GuncellemeTarihi = DateTime.Now;
                etiket.IsActive = model.IsActive;
                etiket.SeoAd = StringManager.SeoDuzenleme(model.Ad);
                await _etiketService.GuncelleAsync(etiket);
                return Json(new ResultJson { Success = true, Message = "Etiket başarıyla düzenlendi." });
            }
            var error = ModelState.Select(x => x.Value.Errors).Where(y => y.Count > 0).ToList();
            model.Etiketler = await _etiketService.TumKayitlarAsync();
            return Json(new ResultJson { Success = false, Message = "Etiket düzenleme başarısız!" });
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var etiket = await _etiketService.BulIdAsync(id);
            if (etiket == null)
            {
                return HttpNotFound();
            }
            DetayEtiketViewModel etiketViewModel = new DetayEtiketViewModel();
            etiketViewModel.Id = etiket.ID;
            etiketViewModel.Ad = etiket.Ad;
            etiketViewModel.Aciklama = etiket.Aciklama;
            etiketViewModel.IsActive = etiket.IsActive;
            etiketViewModel.EklemeTarihi = etiket.EklemeTarihi;
            etiketViewModel.GuncellemeTarihi = etiket.GuncellemeTarihi;
            etiketViewModel.SeoAd = etiket.SeoAd;
            //etiketViewModel.HaberSayisi=etiket.h
            return View(etiketViewModel);
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int? id)
        {
            if (id == null)
            {
                return Json(new ResultJson { Success = false });
            }
            await _etiketService.SilAsync(id);
            return Json(new ResultJson { Success = true });
        }
    }
}