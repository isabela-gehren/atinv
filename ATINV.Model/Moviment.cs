using System;

namespace ATINV.Model
{
    /// <summary>
    /// The moviment object
    /// </summary>
    public class Moviment : Base
    {
        /// <summary>
        /// The fundId in which the moviment will be done
        /// </summary>
        public Guid FundId { get; set; }
        /// <summary>
        /// The fund in which the moviment will be done
        /// </summary>
        public Fund Fund { get; set; }
        /// <summary>
        /// The client´s document
        /// </summary>
        public string Cpf { get; set; }
        /// <summary>
        /// The amount being movimenting
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// The date of the moviment
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// The moviment type: Application or Redemption
        /// </summary>
        public MovimentType MovimentType { get; set; }       
    }
}
