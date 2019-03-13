using MKHaberSistemi.Core.Domain.Entities;
using MKHaberSistemi.Service.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKHaberSistemi.Service.ResimlerService
{
    public interface IGaleriService:IService<Galeri>
    {
        IQueryable<Resim> GetResimler(int? galeriId);

        List<Galeri> TumKayitlar(int[] galeriId);

        void EkleGaleriResim(Resim resim);

    }
}
