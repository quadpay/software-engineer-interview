using System;

namespace Zip.InstallmentsService
{
    /// <summary>
    /// Properties required for installment calculations.
    /// </summary>
    public class InstallmentRequest
    {
        /// <summary>
        /// Get or set purchase order date 
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Get or set order amount
        /// </summary>
        public Decimal OrderAmount { get; set; }
        /// <summary>
        /// Get or set no. of installments customer wants to pay
        /// </summary>
        public int Installments { get; set; }
        /// <summary>
        /// Get or set frequency of installments
        /// </summary>
        public int FrequencyOfInstallment { get; set; }
    }
}
