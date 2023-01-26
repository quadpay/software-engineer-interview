namespace ZipPayment.API.Models
{
    /// <summary>
    /// Defines all the properties for a purchase Payment plan.
    /// </summary>
    public class PaymentPlanDto
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
        public IEnumerable<InstallmentDto> Installments { get; set; } = new List<InstallmentDto>();
    }
}
