using System;
using System.Collections.Generic;

namespace Zip.InstallmentsService.Data.Models
{
    public class PaymentPlan
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public decimal PurchaseAmount { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int NoOfInstallments { get; set; }
        public int FrequencyInDays { get; set; }
        //public int FrequencyType { get; set; }

        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }

        public List<Installment> Installments { get; set; }

    }
}
