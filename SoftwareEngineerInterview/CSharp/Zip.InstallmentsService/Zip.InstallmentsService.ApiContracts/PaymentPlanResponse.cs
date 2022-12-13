namespace Zip.InstallmentsService.ApiContracts
{
    /// <summary>
    /// Used to hold payment plan response
    /// </summary>
    public class PaymentPlanResponse
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the installments <seealso cref="IEnumerable<InstallmentResponse>"/>
        /// </summary>
        public List<InstallmentResponse> Installments { get; set; }

        /// <summary>
        /// Gets or sets the payment plan Id
        /// </summary>
        public Guid PaymentPlanId { get; set; }

        /// <summary>
        /// Gets or sets the purchase amount
        /// </summary>
        public decimal PurchaseAmount { get; set; }        

        #endregion

        #region  Constructor

        /// <summary>
        /// Used to create object of <see cref="PaymentPlanResponse"/>
        /// </summary>
        public PaymentPlanResponse()
        {
            Installments = new List<InstallmentResponse>();
        }

        #endregion
    }
}
