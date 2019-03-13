using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MKHaberSistemi.Service.BaseService
{
    public interface IService<TEntity> where TEntity:class
    {
        // tüm kayıtları getir
        IQueryable<TEntity> TumKayitlar();

        // tüm kayıtları asenkron getir
        Task<ICollection<TEntity>> TumKayitlarAsync();

        //arama kriterine göre kayıt getir
        TEntity Find(Expression<Func<TEntity, bool>> predicate);

        //arama kriterine göre asenkron kayıt getir
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate);

        // arama kriterine göre kayıtları getir
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);

        // arama kriterine göre asenkron kayıtları getir
        Task<ICollection<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);

        // id parametresi ile kaydı bul
        TEntity BulId(int? id);

        // id parametresi ile kaydı bul asenkron
        Task<TEntity> BulIdAsync(int? id);

        // guid id parametresi ile kaydı bul
        TEntity BulGuidId(string id);

        // guid id parametresi ile kaydı bul asenkron
        Task<TEntity> BulGuidIdAsync(string id);

        // kayıt sayısı
        int Count();

        // kayıt sayısı asenkron
        Task<int> CountAsync();

        // kayıt ekle
        TEntity Ekle(TEntity entity);

        // kayıt ekle asenkron
        Task<TEntity> EkleAsync(TEntity entity);

        // kayıt sil
        void Sil(TEntity entity);

        void Sil(int? id);

        // kayıt sil asenkron
        Task SilAsync(TEntity entity);

        Task SilAsync(int? id);

        // kayıt düzenle
        void Guncelle(TEntity entity);

        // kayıt düzenle asenkron
        Task GuncelleAsync(TEntity entity);
    }
}
