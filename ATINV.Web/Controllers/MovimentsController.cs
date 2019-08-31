
using ATINV.Business;
using ATINV.Model;
using ATINV.Utils;
using ATINV.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ATINV.Web.Controllers
{
    /// <summary>
    /// Endpoint responsible for treating moviment requests.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MovimentsController : ApiBase
    {
        private IMapper Mapper { get; set; }
        private IMovimentBusiness Business { get; set; }
        public MovimentsController(IMapper mapper, IMovimentBusiness business)
        {
            this.Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.Business = business ?? throw new ArgumentNullException(nameof(business));
        }

        /// <summary>
        /// Saves a moviment.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<string> Save([FromBody]MovimentViewModel obj)
        {
            var savedObj = Business.Save(Mapper.Map<Moviment>(obj));
            var returnObj = new Response<MovimentViewModel>(Mapper.Map<MovimentViewModel>(savedObj.Entity))
            {
                Messages = savedObj.Messages,
                StatusCode = savedObj.StatusCode
            };
            return base.Message(returnObj);
        }
    }
}