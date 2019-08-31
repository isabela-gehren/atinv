using ATINV.Model;
using ATINV.Utils;

namespace ATINV.Business
{
    /// <summary>
    /// The interface describing Moviment Services.
    /// </summary>
    public interface IMovimentBusiness
    {
        /// <summary>
        /// Saves a Moviment object and returns an object containing the code response for the request
        /// and the saved object, if the request were successful,
        /// or a list of messages describing a problem, if failed.
        /// </summary>
        /// <param name="obj">Moviment object.</param>
        /// <returns></returns>
        Response<Moviment> Save(Moviment obj);
    }
}