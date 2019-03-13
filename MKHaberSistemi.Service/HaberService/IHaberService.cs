using MKHaberSistemi.Core.Domain.Entities;
using MKHaberSistemi.Service.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKHaberSistemi.Service.HaberService
{
    public interface IHaberService:IService<Haber>
    {
        IQueryable<HaberPozisyon> TumHaberPozisyon();
        IQueryable<HaberTip> TumHaberTip();

        IQueryable<Haber> EnCokOkunan(int haberSayisi);
        IQueryable<Haber> TumKayitlar(int pozisyonId,int haberSayisi);
        IQueryable<Yorum> TumYorumlar(int haberId);
        void YorumEkle();
    }
}
