namespace Zip.InstallmentsService.Core.PaymentPlanAggregate
{
    /// <summary>
    /// Used to hold installment information
    /// </summary>
    public class Installment : BaseEntity<Guid>
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the amount of the installment.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the date that the installment payment is due.
        /// </summary>
        public DateTime DueDate { get; set; }

        /// <summary>
        /// Gets or sets the payment plan
        /// </summary>
        public virtual PaymentPlan? PaymentPlan { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Used to create new instance of <see cref="Installment"/>
        /// </summary>
        public Installment()
        {
            Id = Guid.NewGuid();
            CreatedOnUtc = DateTime.UtcNow;
        }

        #endregion
    }
}
