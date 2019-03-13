using MKHaberSistemi.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MKHaberSistemi.Data.Repository
{
    public class GenericRepository<TEntity>:IGenericRepository<TEntity> where TEntity:class
    {
        //private readonly MKHaberSistemiContext _context;
        private readonly ApplicationDbContext _context;
        private readonly IDbSet<TEntity> _dbSet;

        //public GenericRepository(MKHaberSistemiContext context)
        //{
        //    _context = context;
        //    _dbSet = _context.Set<TEntity>();
        //}
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        public virtual TEntity Add(TEntity entity)
        {
            return _dbSet.Add(entity);
        }

        public virtual int Count()
        {
            return _dbSet.Count();
        }

        public virtual async Task<int> CountAsync()
        {
            return await _dbSet.CountAsync();
        }

        public virtual void Delete(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }

        public virtual void Delete(int? id)
        {
            var TEntity = GetById(id);
            if (TEntity != null)
            {
                _dbSet.Remove(TEntity);
            }
        }

        public virtual TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate).SingleOrDefault();
        }

        public virtual async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).SingleOrDefaultAsync();
        }

        public virtual IQueryable<TEntity> Get()
        {
            return _dbSet;
        }

        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public virtual async Task<ICollection<TEntity>> GetAsync()
        {

            return await _context.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<ICollection<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public virtual TEntity GetByGuidId(string id)
        {
            return _dbSet.Find(id);
        }

        public virtual async Task<TEntity> GetByGuidIdAsync(string id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public virtual TEntity GetById(int? id)
        {
            return _dbSet.Find(id);
        }

        public virtual async Task<TEntity> GetByIdAsync(int? id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
