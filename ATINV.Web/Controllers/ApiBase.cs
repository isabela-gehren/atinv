using ATINV.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ATINV.Web.Controllers
{
    public class ApiBase : ControllerBase
    {
        public ActionResult Message<T>(Response<T> response)
        {

            if (response.StatusCode == Utils.StatusCode.OK)
                return Ok(response.Entity);
            else if (response.StatusCode == Utils.StatusCode.InternalServerError)
                return BadRequest(response.Messages);
            else
                return StatusCode((int)response.StatusCode, "Ocorreu um erro. Tente novamente.");
        }
    }
}
