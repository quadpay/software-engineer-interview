using System;

namespace Zip.InstallmentsService
{
    /// <summary>
    /// Get ot set for input parameters for installment calculations.
    /// </summary>
    public class InstallmentRequest
    {
        public DateTime StartDate { get; set; }
        public Decimal OrderAmount { get; set; }
        public int Installments { get; set; }
        public int FrequencyOfInstallment { get; set; }
    }
}
