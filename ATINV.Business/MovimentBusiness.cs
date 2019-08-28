using ATINV.Model;
using ATINV.Repository;
using System;

namespace ATINV.Business
{
    public class MovimentBusiness : IMovimentBusiness
    {
        private IUnitOfWork Uow { get; set; }
        private IMovimentRepository Repository { get; set; }

        public MovimentBusiness(IUnitOfWork uow, IMovimentRepository repository)
        {
            this.Uow = uow ?? throw new ArgumentNullException(nameof(uow));
            this.Repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Moviment Save(Moviment obj)
        {
            using (Uow)
            {
                obj = Repository.Save(obj);
                int commit = Uow.Commit();
            }
            return obj;
        }

    }
}
