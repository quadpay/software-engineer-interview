namespace Zip.InstallmentsService.ApiContracts
{
    /// <summary>
    /// Used to hold installment response
    /// </summary>
    public class InstallmentResponse
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the installment amount rounded upto two decimal points
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the due date in MMM dd, yyyy
        /// </summary>
        public string DueDate { get; set; }

        /// <summary>
        /// Gets or sets the installment identifier
        /// </summary>
        public Guid InstallmentId { get; set; }

        #endregion
    }
}