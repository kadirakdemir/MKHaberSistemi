using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using MKHaberSistemi.Core.Domain.Entities;
using MKHaberSistemi.Data.DataContext;
using MKHaberSistemi.Service.IdentityService;
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
    public class RoleController : Controller
    {
        private ApplicationRoleManager _roleManager;

        public RoleController()
        {
        }

        public RoleController(ApplicationRoleManager roleManager)
        {
            RoleManager = roleManager;
        }

        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }
        // GET: Admin/Role
        public ActionResult Index()
        {
            //RoleManager.Roles.ToList();
            return View();
        }

        public ActionResult Creat()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> Create(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = new ApplicationRole() { Name = model.Name };
                var result = await RoleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return Json(new ResultJson { Message = "Rol başarıyla eklendi!", Success = true });
                }
                AddErrors(result);
            }           
            return Json(new ResultJson { Message = "Rol ekleme başarısız!", Success = false });
        }

        
        public async Task<ActionResult> Edit(string id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = await RoleManager.FindByNameAsync(id);
            if (role==null)
            {
                HttpNotFound();
            }
            return View(new RoleViewModel(role));
        }

        [HttpPost]
        public async Task<JsonResult> Edit(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = new ApplicationRole { Id = model.Id, Name = model.Name };
                var result = await RoleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return Json(new ResultJson { Message = "Rol başarıyla düzenlendi!", Success = true });
                }
                AddErrors(result);
            }
            return Json(new ResultJson { Message = "Rol düzenleme başarısız!", Success = false });
        }

        [HttpPost]
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = await RoleManager.FindByNameAsync(id);
            if (role == null)
            {
                HttpNotFound();
            }
            return View(new RoleViewModel(role));
        }

        [HttpPost]
        public async Task<JsonResult> Delete(string id)
        {
            if (id==null)
            {
                return Json(new ResultJson { Success = false });
            }
            var role = await RoleManager.FindByNameAsync(id);
            var result = await RoleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return Json(new ResultJson { Success = true });
            }
            return Json(new ResultJson { Success = false });
        }


        #region Helpers
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
         #endregion
    }
}