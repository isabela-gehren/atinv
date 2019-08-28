using Microsoft.EntityFrameworkCore;
using System;

namespace ATINV.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext DbContext { get; }
        int Commit();
    }
}
