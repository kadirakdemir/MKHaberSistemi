using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MKHaberSistemi.Data.DataContext;
using MKHaberSistemi.Data.Repository;

namespace MKHaberSistemi.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        //private readonly MKHaberSistemiContext _context;
        private readonly ApplicationDbContext _context;

        private bool disposed = false;

        //public UnitOfWork(MKHaberSistemiContext context)
        //{
        //    _context = context;
        //}
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            return new GenericRepository<TEntity>(_context);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
