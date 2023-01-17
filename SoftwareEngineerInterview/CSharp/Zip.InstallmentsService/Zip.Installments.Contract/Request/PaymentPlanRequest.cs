namespace Zip.Installments.Contract.Request
{
    /// <summary>
    /// Class declares properties that are used to create installement plan.
    /// </summary>
    public class PaymentPlanRequest 
    {
        /// <summary>
        /// Actual amount.
        /// </summary>
        public decimal Amount { get; set; }
        
        /// <summary>
        /// Number of installement.
        /// </summary>
        public int NumofInstallement { get; set; }

        /// <summary>
        /// Frequency of installement.
        /// </summary>
        public int Frequency { get; set; }
    }
}
