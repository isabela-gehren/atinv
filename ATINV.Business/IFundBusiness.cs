using ATINV.Model;
using ATINV.Utils;
using System.Collections.Generic;

namespace ATINV.Business
{
    public interface IFundBusiness
    {
        Response<List<Fund>> List();
    }
}