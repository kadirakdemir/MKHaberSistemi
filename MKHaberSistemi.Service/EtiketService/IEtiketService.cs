using MKHaberSistemi.Core.Domain.Entities;
using MKHaberSistemi.Service.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKHaberSistemi.Service.EtiketService
{
    public interface IEtiketService : IService<Etiket>
    {
        Task<bool> IsValid(string name);
        ICollection<Etiket> HaberCount(int id);
        List<Etiket> TumKayitlar(int[] etiketId);
        //Task<ICollection<Etiket>> TumKayitlarAsync(int[] etiketId);
    }
}
