using Microsoft.EntityFrameworkCore;
using System;

namespace ATINV.Repository
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private DbContext _dbContext;

        public UnitOfWork(DbContext context)
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public int Commit()
        {
            //Save changes with the default options
            return _dbContext.SaveChanges();
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
