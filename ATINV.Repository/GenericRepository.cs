
using ATINV.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ATINV.Repository
{
    /// <summary>
    /// The generic repository implementation of the IGenericRepository interface, 
    /// serving the default operations: List, Get, Delete and Save.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : Base
    {
        protected DbContext _context;
        protected DbSet<T> _dbset;
        private IUnitOfWork _unit;

        protected IUnitOfWork Unit { get { return _unit; } }

        /// <summary>
        /// The class constructor.
        /// </summary>
        /// <param name="unit"></param>
        public GenericRepository(IUnitOfWork unit)
        {
            _context = unit.DbContext;
            _dbset = _context.Set<T>();
            _unit = unit;
        }

        /// <summary>
        /// Delete a specific object of T type, by id.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(Guid id)
        {
            var obj = _dbset.FirstOrDefaultAsync(i => i.Id == id).Result;
            if (obj.Id != Guid.Empty)
                _dbset.Remove(obj);
        }

        /// <summary>
        /// Get a specific object of T type, by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Get(Guid id)
        {
            var query = _dbset.FirstOrDefaultAsync(i => i.Id == id).Result;
            return (T)query;
        }

        /// <summary>
        /// Lists all the objects of T type.
        /// </summary>
        /// <returns></returns>
        public IList<T> List()
        {
            return _dbset.ToListAsync().Result;
        }

        /// <summary>
        /// Save a object of T type, updating it if id is passed, or creating a new one if not.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public T Save(T obj)
        {
            obj = _dbset.Update(obj).Entity;
            return obj;
        }
    }
}
