using MKHaberSistemi.Core.Domain.Entities;
using MKHaberSistemi.Service.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKHaberSistemi.Service.KategoriService
{
    public interface IKategoriService:IService<Kategori>
    {
        string UstKategoriAdi(int? id);
    }
}
