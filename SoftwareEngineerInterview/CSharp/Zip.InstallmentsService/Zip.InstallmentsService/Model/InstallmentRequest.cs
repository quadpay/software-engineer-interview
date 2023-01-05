using System;
using System.ComponentModel.DataAnnotations;

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
        [Required]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Get or set order amount
        /// </summary>
        [Required]
        public Decimal OrderAmount { get; set; }
        /// <summary>
        /// Get or set no. of installments customer wants to pay
        /// </summary>
        [Required]
        public int Installments { get; set; }
        /// <summary>
        /// Get or set frequency of installments
        /// </summary>
        [Required]
        public int FrequencyOfInstallment { get; set; }
    }
}
