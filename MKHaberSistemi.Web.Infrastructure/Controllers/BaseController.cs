using MKHaberSistemi.Data.UnitOfWork;
using System.Web.Mvc;

namespace MKHaberSistemi.Web.Infrastructure.Controllers
{
    public class BaseController:Controller
    {
        protected readonly IUnitOfWork _unitOfWork;
        public BaseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
