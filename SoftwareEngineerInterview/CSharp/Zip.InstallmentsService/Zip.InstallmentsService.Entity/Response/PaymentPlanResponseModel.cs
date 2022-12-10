using System;
using System.Collections.Generic;
using System.Text;

namespace Zip.InstallmentsService.Entity.Response
{
    /// <summary>
    /// Data structure which defines all the properties for a purchase installment plan.
    /// </summary>
    public class PaymentPlanResponseModel
    {
        public Guid Id { get; set; }

        public decimal PurchaseAmount { get; set; }

        public InstallmentResponseModel[] Installments { get; set; }
    }
}
