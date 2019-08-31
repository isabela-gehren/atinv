using ATINV.Model;
using ATINV.Repository;
using ATINV.Utils;
using System;
using System.Collections.Generic;

namespace ATINV.Business
{
    /// <summary>
    /// The class that manipulates Moviment objects.
    /// </summary>
    public class MovimentBusiness : IMovimentBusiness
    {
        private IUnitOfWork Uow { get; set; }
        private IMovimentRepository Repository { get; set; }

        /// <summary>
        /// The class constructor.
        /// </summary>
        /// <param name="uow"></param>
        /// <param name="repository"></param>
        public MovimentBusiness(IUnitOfWork uow, IMovimentRepository repository)
        {
            this.Uow = uow ?? throw new ArgumentNullException(nameof(uow));
            this.Repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        /// <summary>
        /// Validates and, if successful, saves a Moviment object.
        /// </summary>
        /// <param name="obj">Moviment object, representing a redemption or application moviment.</param>
        /// <returns></returns>
        public Response<Moviment> Save(Moviment obj)
        {
            Response<Moviment> response = new Response<Moviment>();
            try
            {
                var msgs = ValidateMoviment(obj);
                if(msgs.Count > 0)
                {
                    response.StatusCode = StatusCode.BadRequest;
                    response.Messages = msgs;
                    return response;
                }

                using (Uow)
                {
                    response.Entity = Repository.Save(obj);
                    int commit = Uow.Commit();
                }
            }
            catch (Exception ex)
            {
                response.ReponseException(ex);
            }
            return response;
        }

        private List<string> ValidateMoviment(Moviment obj)
        {
            var validationMsgs = new List<string>();

            if (obj.FundId == null || obj.FundId == Guid.Empty)
                validationMsgs.Add("É necessário informar um fundo para aplicação/resgate");
            if (string.IsNullOrWhiteSpace(obj.Cpf))
                validationMsgs.Add("É necessário informar o CPF para aplicação/resgate");
            if (obj.Date == DateTime.MinValue)
                validationMsgs.Add("É necessário informar a data para aplicação/resgate");
            if (obj.Amount <= default(decimal))
                validationMsgs.Add("É necessário informar o valor para aplicação/resgate");
            if (!string.IsNullOrWhiteSpace(obj.Cpf) && !Validators.CpfIsValid(obj.Cpf))
                validationMsgs.Add("É necessário informar um CPF válido");

            return validationMsgs;
        }
    }
}
