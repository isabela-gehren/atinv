using ATINV.Model;
using ATINV.Repository;
using ATINV.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ATINV.Business
{
    /// <summary>
    /// The class that manipulates Fund objects, implementing IFundBusines interface.
    /// </summary>
    public class FundBusiness : IFundBusiness
    {
        private IUnitOfWork Uow { get; set; }
        private IFundRepository Repository { get; set; }
        /// <summary>
        /// The class constructor.
        /// </summary>
        /// <param name="uow"></param>
        /// <param name="repository"></param>
        public FundBusiness(IUnitOfWork uow, IFundRepository repository)
        {
            this.Uow = uow ?? throw new ArgumentNullException(nameof(uow));
            this.Repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        /// <summary>
        /// Lists all Fund objects.
        /// </summary>
        /// <returns></returns>
        public Response<List<Fund>> List()
        {
            IList<Fund> fundList;
            using (Uow)
            {
                fundList = Repository.List();
            }
            return new Response<List<Fund>>(fundList.ToList());
        }
    }
}
