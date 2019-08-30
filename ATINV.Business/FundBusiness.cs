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
        private IFundRepository Repository { get; set; }
        public FundBusiness(IFundRepository repository)
        {
            this.Repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Response<List<Fund>> List()
        {
            return new Response<List<Fund>>(Repository.List().ToList());
        }
    }
}
