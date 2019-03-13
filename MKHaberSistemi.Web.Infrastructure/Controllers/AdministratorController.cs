using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using MKHaberSistemi.Core.Domain;
using MKHaberSistemi.Data.UnitOfWork;
using MKHaberSistemi.Service.IdentityService;

namespace MKHaberSistemi.Web.Infrastructure.Controllers
{
    [Authorize(Roles =AppConstants.Role_Administrator)]
    public class AdministratorController : BaseController
    {
        //private ApplicationSignInManager _signInManager;
        //private ApplicationUserManager _userManager;
        //private ApplicationRoleManager _rolManager;
        public AdministratorController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
