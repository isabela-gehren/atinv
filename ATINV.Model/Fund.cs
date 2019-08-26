using System;
using System.Collections.Generic;

namespace ATINV.Model
{
    public class Fund : Base
    {
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public decimal MinInicialContribution { get; set; }
        public virtual IList<Moviment> Moviments { get; set; }
    }
}
