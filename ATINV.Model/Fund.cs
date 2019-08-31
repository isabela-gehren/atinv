using System;
using System.Collections.Generic;

namespace ATINV.Model
{
    public class Fund : Base
    {
        /// <summary>
        /// The Fund´s name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The Fund´s CNPJ
        /// </summary>
        public string Cnpj { get; set; }
        /// <summary>
        /// The minimal inicial contribution to the fund
        /// </summary>
        public decimal MinInicialContribution { get; set; }
        public virtual IList<Moviment> Moviments { get; set; }
    }
}
