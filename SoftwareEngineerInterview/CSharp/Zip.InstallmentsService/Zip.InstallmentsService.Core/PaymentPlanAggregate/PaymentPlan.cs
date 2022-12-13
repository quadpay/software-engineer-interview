namespace Zip.InstallmentsService.Core.PaymentPlanAggregate
{
    /// <summary>
    /// Used to hold payment plan information
    /// </summary>
    public class PaymentPlan : BaseEntity<Guid>
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the installment list
        /// </summary>
        public virtual List<Installment> Installments { get; set; }

        /// <summary>
        /// Gets or sets the purchase amount
        /// </summary>
        public decimal PurchaseAmount { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Used to create instance of <see cref="PaymentPlan"/>
        /// </summary>
        /// <param name="purchaseAmount">Purchase amount</param>
        public PaymentPlan(decimal purchaseAmount)
        {
            Id = Guid.NewGuid();
            Installments = new List<Installment>();
            PurchaseAmount = purchaseAmount;
            CreatedOnUtc = DateTime.UtcNow;
        }

        /// <summary>
        /// Used to create instance of <see cref="PaymentPlan"/>
        /// </summary>
        public PaymentPlan()
        {
            Id = Guid.NewGuid();
            Installments = new List<Installment>();
            CreatedOnUtc = DateTime.UtcNow;
        }

        #endregion

        #region Public Method

        /// <summary>
        /// Generates new payment plan based on inputs
        /// </summary>
        /// <param name="purhcaseDate">The purchase date</param>
        /// <param name="numberOfInstallments">Number of installments</param>
        /// <param name="frequency">Frequency for installments</param>
        /// <returns><see cref="PaymentPlan"/></returns>
        public PaymentPlan CreatePaymentPlan(DateTime purhcaseDate,
                                             int numberOfInstallments,
                                             int frequency)
        {
            if (this.PurchaseAmount <= 1 || numberOfInstallments == 0 || frequency == 0 || purhcaseDate == default)
            {
                return this;
            }

            var installmentAmount = Math.Round(this.PurchaseAmount / numberOfInstallments, 2);

            Installments = Enumerable.Range(0, numberOfInstallments).Select(i => new Installment()
            {
                Id = Guid.NewGuid(),
                Amount = installmentAmount,
                DueDate = purhcaseDate.AddDays(i * frequency)
            }).ToList();

            return this;
        }

        #endregion
    }
}
