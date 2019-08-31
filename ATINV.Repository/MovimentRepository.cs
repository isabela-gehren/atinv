using ATINV.Model;

namespace ATINV.Repository
{
    /// <summary>
    /// The especialized repository for Moviment operations.
    /// </summary>
    public class MovimentRepository : GenericRepository<Moviment>, IMovimentRepository
    {
        public MovimentRepository(IUnitOfWork unit) : base(unit)
        {
        }
    }
}
