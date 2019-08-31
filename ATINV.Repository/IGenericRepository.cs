using System;
using System.Collections;
using System.Collections.Generic;

namespace ATINV.Repository
{
    /// <summary>
    /// Describes a generic repository, representing the default operations: List, Get, Delete and Save.
    /// </summary>
    /// <typeparam name="T">Any object in the database</typeparam>
    public interface IGenericRepository<T>
    {
        /// <summary>
        /// Lists all the objects of T type.
        /// </summary>
        /// <returns></returns>
        IList<T> List();
        /// <summary>
        /// Get a specific object of T type, by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(Guid id);
        /// <summary>
        /// Delete a specific object of T type, by id.
        /// </summary>
        /// <param name="id"></param>
        void Delete(Guid id);
        /// <summary>
        /// Save a object of T type, updating it if id is passed, or creating a new one if not.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        T Save(T obj);
    }
}
