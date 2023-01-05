namespace Zip.InstallmentsService
{
    /// <summary>
    /// Properties of response need to be sent to customer
    /// </summary>
    public class InstallmentResponse
    {
        /// <summary>
        /// Get or set Payment plan class object
        /// </summary>
       public PaymentPlan PaymentPlan { get; set; }
        /// <summary>
        /// Get or set response message needs to be sent to customer
        /// </summary>
        public string ResponseMessage { get; set; }
        /// <summary>
        /// Get or set http status code
        /// </summary>
        public int StatusCode { get; set; }
        /// <summary>
        /// Get or set status process of request
        /// </summary>
        public bool Status { get; set; }
    }
}
