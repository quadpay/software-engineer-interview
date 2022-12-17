using System;

namespace Zip.Installments.DAL.Models
{
    /// <summary>
    /// Data structure which defines all the properties for a purchase installment plan.
    /// </summary>
    public class PaymentPlan
    {
        public Guid Id { get; set; }

		public decimal PurchaseAmount { get; set; }

        public ICollection<Installment> Installments { get; set; }
    }
}
