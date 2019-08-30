using ATINV.Model;
using ATINV.Utils;

namespace ATINV.Business
{
    public interface IMovimentBusiness
    {
        Response<Moviment> Save(Moviment obj);
    }
}