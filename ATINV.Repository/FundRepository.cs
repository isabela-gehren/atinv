using ATINV.Model;

namespace ATINV.Repository
{
    public class FundRepository : GenericRepository<Fund>, IFundRepository
    {
        public FundRepository(IUnitOfWork unit) : base(unit)
        {
        }
    }
}
