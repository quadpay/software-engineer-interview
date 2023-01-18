namespace Zip.Installments.Contract.Response
{
    /// <summary>
    /// Class declares properties that are used as a response of payment installment details 
    /// </summary>
    public class InstallmentDetailsResponse
    {
        /// <summary>
        /// Due date.
        /// </summary>
        public string DueDate { get; set; }

        /// <summary>
        /// Due amount.
        /// </summary>
        public decimal DueAmount { get; set; }

        /// <summary>
        /// Payment id.
        /// </summary>
        public int PaymentId { get; set; }
    }
}
