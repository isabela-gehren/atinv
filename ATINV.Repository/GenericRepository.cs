
using ATINV.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ATINV.Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : Base
    {
        protected DbContext _context;
        protected DbSet<T> _dbset;
        private IUnitOfWork _unit;

        protected IUnitOfWork Unit { get { return _unit; } }

        public GenericRepository(IUnitOfWork unit)
        {
            _context = unit.DbContext;
            _dbset = _context.Set<T>();
            _unit = unit;
        }

        public void Delete(Guid id)
        {
            var obj = _dbset.FirstOrDefaultAsync(i => i.Id == id).Result;
            if (obj.Id != Guid.Empty)
                _dbset.Remove(obj);
        }

        public T Get(Guid id)
        {
            var query = _dbset.FirstOrDefaultAsync(i => i.Id == id).Result;
            return (T)query;
        }

        public IList<T> List()
        {
            return _dbset.ToListAsync().Result;
        }

        public T Save(T obj)
        {
            obj = _dbset.Update(obj).Entity;
            return obj;
        }
    }
}
