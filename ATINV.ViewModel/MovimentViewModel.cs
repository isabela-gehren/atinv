using System;
using System.Collections.Generic;
using System.Text;

namespace ATINV.ViewModel
{
    public class MovimentViewModel
    {
        public Guid FundId { get; set; }
        public string Cpf { get; set; }
        public decimal Amount { get; set; }
        public string Date { get; set; }
        public string MovimentType { get; set; }
    }
}
