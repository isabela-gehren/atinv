using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace ATINV.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FundsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

    }
}
