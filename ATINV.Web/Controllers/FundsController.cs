using System;
using System.Collections.Generic;
using ATINV.Business;
using ATINV.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ATINV.ViewModel;
using ATINV.Utils;

namespace ATINV.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FundsController : ApiBase
    {
        private IMapper Mapper { get; set; }
        private IFundBusiness FundBusiness { get; set; }

        public FundsController(IMapper mapper, IFundBusiness fundBusiness)
        {
            this.Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.FundBusiness = fundBusiness ?? throw new ArgumentNullException(nameof(fundBusiness));
        }

        [HttpGet]
        public ActionResult<IList<Fund>> Get()
        {
            var fundViewModelList = new List<FundViewModel>();
            var fundList = FundBusiness.List();
            fundList.Entity.ForEach(i =>
            {
                fundViewModelList.Add(Mapper.Map<FundViewModel>(i));
            });

            return base.Message(new Response<List<FundViewModel>>(fundViewModelList)
            {
                Messages = fundList.Messages,
                StatusCode = fundList.StatusCode
            });
        }
    }
}
