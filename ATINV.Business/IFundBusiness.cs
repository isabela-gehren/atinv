using ATINV.Model;
using ATINV.Utils;
using System.Collections.Generic;

namespace ATINV.Business
{
    /// <summary>
    /// The interface describing Fund Services.
    /// </summary>
    public interface IFundBusiness
    {
        /// <summary>
        /// Returns an object containing the code response for the request 
        /// and the list of Funds, if the request were successful,
        /// or a list of messages describing a problem, if failed.
        /// </summary>
        /// <returns></returns>
        Response<List<Fund>> List();
    }
}