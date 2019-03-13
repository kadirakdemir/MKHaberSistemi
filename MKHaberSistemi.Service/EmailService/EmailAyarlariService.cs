using MKHaberSistemi.Core.Domain.Entities;
using MKHaberSistemi.Data.UnitOfWork;
using MKHaberSistemi.Service.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKHaberSistemi.Service.EmailService
{
    public class EmailAyarlariService : BaseService<EmailAyarlari>, IEmailAyarlariService
    {
        public EmailAyarlariService(IUnitOfWork uow) : base(uow)
        {
        }
    }
}
