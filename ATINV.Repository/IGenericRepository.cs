using System;
using System.Collections;
using System.Collections.Generic;

namespace ATINV.Repository
{
    public interface IGenericRepository<T>
    {
        IEnumerable<T> List();
        T Get(Guid id);
        void Delete(Guid id);
        T Save(T obj);
    }
}
