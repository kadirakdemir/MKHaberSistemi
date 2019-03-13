using MKHaberSistemi.Core.Domain.Entities;
using MKHaberSistemi.Data.UnitOfWork;
using MKHaberSistemi.Service.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKHaberSistemi.Service.ResimService
{
    public class ResimService : BaseService<Resim>, IResimService
    {
        public ResimService(IUnitOfWork uow) : base(uow)
        {
        }
    }
}
