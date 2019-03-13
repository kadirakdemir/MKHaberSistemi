using MKHaberSistemi.Core.Domain.Entities;
using MKHaberSistemi.Data.Repository;
using MKHaberSistemi.Data.UnitOfWork;
using MKHaberSistemi.Service.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKHaberSistemi.Service.KategoriService
{
    public class KategoriService : BaseService<Kategori>, IKategoriService
    {

        IGenericRepository<Kategori> _kategori;
        public KategoriService(IUnitOfWork uow) : base(uow)
        {
            _kategori = uow.GetRepository<Kategori>();
        }

        public string UstKategoriAdi(int? id)
        {
            if (_kategori.GetById(id).Ad == null)
            {
                return "-";
            }
            return _kategori.GetById(id).Ad;
        }
    }
}
