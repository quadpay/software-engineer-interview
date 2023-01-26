using System;

namespace Zip.InstallmentsService.DomainObjects
{
    /// <summary>
    /// Data structure which defines all the properties for a purchase installment plan.
    /// </summary>
    public class PaymentPlan
    {
        /// <summary>
        /// Gets or sets the unique identifier for each payment plan.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the purchase amount of the installment.
        /// </summary>
        public decimal PurchaseAmount { get; set; }

        /// <summary>
        /// Gets or sets the installments.
        /// </summary>
        public Installment[] Installments { get; set; }
    }
}
