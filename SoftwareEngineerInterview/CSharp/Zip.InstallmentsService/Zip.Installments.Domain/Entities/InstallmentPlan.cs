namespace Zip.Installments.Domain.Entities
{
    using Zip.Installments.Domain.BaseEntity;

    /// <summary>
    /// Class declares properties of intallmentplan entity class.
    /// </summary>
    public class InstallmentPlan : Entity
    {
        /// <summary>
        /// Due date.
        /// </summary>
        public DateTimeOffset DueDate { get; set; }

        /// <summary>
        /// Due amount.
        /// </summary>
        public decimal DueAmount { get; set; }

        //Navigation property
        public virtual Payment Payment { get; set; }

        public int PaymentId { get; set; }
    }
}
