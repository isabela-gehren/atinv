using ATINV.Model;

namespace ATINV.Repository
{
    /// <summary>
    /// The especialized repository for Fund operations.
    /// </summary>
    public class FundRepository : GenericRepository<Fund>, IFundRepository
    {
        public FundRepository(IUnitOfWork unit) : base(unit)
        {
        }
    }
}
