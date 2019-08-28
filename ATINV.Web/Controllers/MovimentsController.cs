
using ATINV.Business;
using ATINV.Model;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ATINV.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimentsController : ControllerBase
    {
        private IMovimentBusiness Business { get; set; }
        public MovimentsController(IMovimentBusiness business)
        {
            this.Business = business ?? throw new ArgumentNullException(nameof(business));
        }

        [HttpPost]
        public ActionResult<Moviment> Save([FromBody]Moviment obj)
        {
            return Ok(Business.Save(obj));
        }
    }
}