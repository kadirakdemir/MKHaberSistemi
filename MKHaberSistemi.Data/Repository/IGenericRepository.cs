using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MKHaberSistemi.Data.Repository
{
    public interface IGenericRepository<TEntity> where TEntity:class
    {
        IQueryable<TEntity> Get();
        Task<ICollection<TEntity>> GetAsync();
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        Task<ICollection<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);
        TEntity GetById(int? id);
        Task<TEntity> GetByIdAsync(int? id);
        TEntity GetByGuidId(string id);
        Task<TEntity> GetByGuidIdAsync(string id);
        TEntity Find(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate);
        int Count();
        Task<int> CountAsync();
        TEntity Add(TEntity entity);       
        void Update(TEntity entity);      
        void Delete(TEntity entity);       
        void Delete(int? id);     
        void Save();
    }
}
