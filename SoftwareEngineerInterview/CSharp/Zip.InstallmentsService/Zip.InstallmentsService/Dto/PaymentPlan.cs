using System;
using System.ComponentModel.DataAnnotations;

namespace Zip.InstallmentsService.Dto
{
    /// <summary>
    /// Data structure which defines all the properties for a purchase installment plan.
    /// </summary>
    public class PaymentPlan
    {
       
        public string PaymentPlanId { get; set; }

        public decimal PurchaseAmount { get; set; }

        public int Installments { get; set; }

        public int FrequencyInDays { get; set; }  
    }
}
