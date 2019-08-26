using Microsoft.EntityFrameworkCore;
using System;

namespace ATINV.Repository
{
    public sealed class UnitOfWork : IUnitOfWork, IDisposable
    {
        private DbContext _dbContext;

        public UnitOfWork()
        {
            _dbContext = new AppDbContext(null);
        }

        public int Commit()
        {
            //Save changes with the default options
            return _dbContext.SaveChanges();
        }

        public DbContext ReCreateContext()
        {
            _dbContext.Dispose();
            _dbContext = new AppDbContext(null);
            return _dbContext;
        }

        public void Dispose()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
                _dbContext = null;
            }
            GC.SuppressFinalize(this);
        }

        DbContext IUnitOfWork.DbContext
        {
            get
            {
                return _dbContext;
            }
        }
    }
}
