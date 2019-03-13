using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MKHaberSistemi.Data.UnitOfWork;

namespace MKHaberSistemi.Web.Infrastructure.Controllers
{
    public class AuthorizedController : BaseController
    {
        public AuthorizedController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
