using System;

namespace ATINV.Model
{
    public class Moviment : Base
    {
        public Guid FundId { get; set; }
        public Fund Fund { get; set; }
        public string Cpf { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public MovimentType MovimentType { get; set; }       
    }
}
