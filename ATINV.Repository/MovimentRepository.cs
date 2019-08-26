using ATINV.Model;

namespace ATINV.Repository
{
    public class MovimentRepository : GenericRepository<Moviment>, IMovimentRepository
    {
        public MovimentRepository(IUnitOfWork unit) : base(unit)
        {
        }
    }
}
