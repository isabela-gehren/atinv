using System.Collections.Generic;
using ATINV.Business;
using ATINV.Model;
using Microsoft.AspNetCore.Mvc;

namespace ATINV.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FundsController : ControllerBase
    {
        private IFundBusiness FundBusiness { get; set; }
        public FundsController(IFundBusiness fundBusiness)
        {
            this.FundBusiness = fundBusiness;
        }
        
        [HttpGet]
        public ActionResult<IList<Fund>> Get()
        {
            return Ok(FundBusiness.List());
        }
    }
}
