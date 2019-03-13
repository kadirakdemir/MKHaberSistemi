using MKHaberSistemi.Core.Domain.Entities;
using MKHaberSistemi.Data.Repository;
using MKHaberSistemi.Data.UnitOfWork;
using MKHaberSistemi.Service.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKHaberSistemi.Service.EtiketService
{
    public class EtiketService : BaseService<Etiket>, IEtiketService
    {
        private readonly IGenericRepository<Etiket> _etiket;
        private readonly IGenericRepository<Haber> _haber;
        private readonly IGenericRepository<Kategori> _kategori;
        public EtiketService(IUnitOfWork uow) : base(uow)
        {
            _etiket = uow.GetRepository<Etiket>();
            _haber = uow.GetRepository<Haber>();
            _kategori = uow.GetRepository<Kategori>();
        }

        public ICollection<Etiket> HaberCount(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsValid(string name)
        {
            var result = await _etiket.FindAsync(x=>x.Ad==name);
            if (result==null)
            {
                return true;
            }
            return false;            
        }

        public List<Etiket> TumKayitlar(int[] etiketId)
        {
            if (etiketId!=null)
            {
                return _etiket.Get().Where(x=>etiketId.Contains(x.ID)).ToList();
            }
            return new List<Etiket>();
        }

        //public async Task<ICollection<Etiket>> TumKayitlarAsync(int[] etiketId)
        //{
        //    if (etiketId!=null)
        //    {
        //       var a= await _etiket.Get().Where(x => etiketId.Contains(x.ID)).ToListAsync();
        //        return a;
        //    }
        //    return await new  ICollection<Etiket>();
        //}
    }
}
