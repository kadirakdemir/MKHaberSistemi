using MKHaberSistemi.Core.Domain.Entities;
using MKHaberSistemi.Data.Repository;
using MKHaberSistemi.Data.UnitOfWork;
using MKHaberSistemi.Service.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKHaberSistemi.Service.HaberService
{
    public class HaberService : BaseService<Haber>, IHaberService
    {
        private readonly IGenericRepository<HaberTip> _haberTip;
        private readonly IGenericRepository<HaberPozisyon> _haberPozisyon;
        private readonly IGenericRepository<Yorum> _yorum;
        private readonly IGenericRepository<Haber> _haber;
        public HaberService(IUnitOfWork uow) : base(uow)
        {
            _haberTip = uow.GetRepository<HaberTip>();
            _haberPozisyon = uow.GetRepository<HaberPozisyon>();
            _haber = uow.GetRepository<Haber>();
            _yorum = uow.GetRepository<Yorum>();
        }

        public IQueryable<Haber> EnCokOkunan(int haberSayisi)
        {
            throw new NotImplementedException();
        }

        public IQueryable<HaberPozisyon> TumHaberPozisyon()
        {
            return _haberPozisyon.Get();
        }

        public IQueryable<HaberTip> TumHaberTip()
        {
            return _haberTip.Get();
        }

        public IQueryable<Haber> TumKayitlar(int pozisyonId, int haberSayisi)
        {
           var a= _haber.Get(x=>x.IsYayinlandiMi==true &&x.HaberPozisyonID==pozisyonId).OrderByDescending(x=>x.ID).Take(4);
          return a;
        }

        public IQueryable<Yorum> TumYorumlar(int haberId)
        {
            throw new NotImplementedException();
        }

        public void YorumEkle()
        {
            throw new NotImplementedException();
        }
    }
}
