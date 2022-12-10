using System;
using System.Collections.Generic;
using System.Text;
using Zip.InstallmentsService.Entity.Enum;

namespace Zip.InstallmentsService.Entity.Request
{
    /// <summary>
    /// Data structure which defines all the properties for a PaymentPlan Requests.
    /// </summary>
    public class PaymentPlanRequestModel
    {
        public Guid Id { get; set; }
    }

    public class CreatePaymentPlanRequestModel
    {
        public Guid Id { get; set; }
        public decimal PurchaseAmount { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int NoOfInstallments { get; set; }
        public int Frequency { get; set; }

        /// <summary>
        /// Defines cycle type like weekly, monthly etc etc
        /// </summary>
        public PaymentPlanFrequencyTypeEnum FrequencyType { get; set; }

        /// <summary>
        /// Defines cycle type value like 6 week, 1 month etc etc
        /// </summary>
        public int PaymentPlanCycleValue { get; set; }

        
    }

}
