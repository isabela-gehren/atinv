using ATINV.Model;
using ATINV.Repository;
using ATINV.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ATINV.Business
{
    public class FundBusiness : IFundBusiness
    {
        private IUnitOfWork Uow { get; set; }
        private IFundRepository Repository { get; set; }
        public FundBusiness(IUnitOfWork uow, IFundRepository repository)
        {
            this.Uow = uow ?? throw new ArgumentNullException(nameof(uow));
            this.Repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

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
