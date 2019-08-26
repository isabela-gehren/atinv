using Microsoft.EntityFrameworkCore;

namespace ATINV.Repository
{
    public interface IUnitOfWork
    {
        DbContext DbContext { get; }
    }
}
