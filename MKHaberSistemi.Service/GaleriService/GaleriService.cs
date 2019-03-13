using MKHaberSistemi.Core.Domain.Entities;
using MKHaberSistemi.Data.Repository;
using MKHaberSistemi.Data.UnitOfWork;
using MKHaberSistemi.Service.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKHaberSistemi.Service.ResimlerService
{
    public class GaleriService : BaseService<Galeri>,IGaleriService
    {
        private readonly IGenericRepository<Galeri> _galeri;
        private readonly IGenericRepository<Resim> _resim;
        private readonly IUnitOfWork _uow;
        public GaleriService(IUnitOfWork uow) : base(uow)
        {
            _galeri = uow.GetRepository<Galeri>();
            _resim = uow.GetRepository<Resim>();
            _uow = uow;
        }

        public void EkleGaleriResim(Resim resim)
        {
            _resim.Add(resim);
            _uow.SaveChanges();
           
        }

        public IQueryable<Resim> GetResimler(int? galeriId)
        {
            return _resim.Get(x => x.GaleriID == galeriId).OrderBy(x=>x.ID);
        }       

        public List<Galeri> TumKayitlar(int[] resimlerId)
        {
            if (resimlerId!=null)
            {
                return _galeri.Get(x => resimlerId.Contains(x.ID)).ToList();
            }
            return new List<Galeri>(); 
        }
    }
}
