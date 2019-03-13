using MKHaberSistemi.Data.Repository;
using MKHaberSistemi.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MKHaberSistemi.Service.BaseService
{
    public class BaseService<TEntity> : IService<TEntity> where TEntity : class
    {
        private readonly IGenericRepository<TEntity> _repository;
        private readonly IUnitOfWork _uow;
        public BaseService(IUnitOfWork uow)
        {
            _repository = uow.GetRepository<TEntity>();
            _uow = uow;
        }
        public TEntity BulId(int? id)
        {
            return _repository.GetById(id);
        }
       
        public async Task<TEntity> BulIdAsync(int? id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public TEntity BulGuidId(string id)
        {
            return _repository.GetByGuidId(id);
        }

        public async Task<TEntity> BulGuidIdAsync(string id)
        {
            return await _repository.GetByGuidIdAsync(id);
        }

        public int Count()
        {
            return _repository.Count();
        }

        public async Task<int> CountAsync()
        {
            return await _repository.CountAsync();
        }

        public TEntity Ekle(TEntity entity)
        {
            _repository.Add(entity);
            _uow.SaveChanges();
            return entity;
        }

        public async Task<TEntity> EkleAsync(TEntity entity)
        {
            _repository.Add(entity);
            await _uow.SaveChangesAsync();
            return entity;
        }

        public TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.Find(predicate);
        }

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repository.FindAsync(predicate);
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.Get(predicate);
        }

        public async Task<ICollection<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repository.GetAsync(predicate);
        }

        public void Guncelle(TEntity entity)
        {
            _repository.Update(entity);
            _uow.SaveChanges();
        }

        public async Task GuncelleAsync(TEntity entity)
        {
            _repository.Update(entity);
            await _uow.SaveChangesAsync();
        }

        public void Sil(TEntity entity)
        {
            _repository.Delete(entity);
            _uow.SaveChanges();
        }
        public void Sil(int? id)
        {
            _repository.Delete(id);
            _uow.SaveChanges();
        }

        public async Task SilAsync(TEntity entity)
        {
            _repository.Delete(entity);
            await _uow.SaveChangesAsync();
        }

        public async Task SilAsync(int? id)
        {
            _repository.Delete(id);
            await _uow.SaveChangesAsync();
        }

        public IQueryable<TEntity> TumKayitlar()
        {
            return _repository.Get();
        }

        public async Task<ICollection<TEntity>> TumKayitlarAsync()
        {
            return await _repository.GetAsync();
        }
    }
}
