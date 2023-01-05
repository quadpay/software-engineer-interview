using System;
using System.Collections.Generic;

namespace Zip.InstallmentsService
{
    /// <summary>
    /// Data structure which defines all the properties for a purchase installment plan.
    /// </summary>
    public class PaymentPlan
    {
        /// <summary>
        /// Get or set unique identifier Id for each payment plan
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// get or set propery for parchase  amount    
        /// </summary>
		public decimal PurchaseAmount { get; set; }   

        /// <summary>
        /// Get or set list of Installment details for each purchase order
        /// </summary>
        public List<Installment> Installments { get; set; }  
    }
}
