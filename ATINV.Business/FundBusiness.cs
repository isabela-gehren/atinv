using ATINV.Model;
using ATINV.Repository;
using System;
using System.Collections.Generic;

namespace ATINV.Business
{
    public class FundBusiness : IFundBusiness
    {
        private IFundRepository Repository { get; set; }
        public FundBusiness(IFundRepository repository)
        {
            this.Repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public IList<Fund> List()
        {
            return Repository.List();
        }
    }
}
