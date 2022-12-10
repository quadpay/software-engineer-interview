using System;
using System.Collections.Generic;
using System.Text;
using Zip.InstallmentsService.Entity.Dto;
using Zip.InstallmentsService.Entity.Enum;

namespace Zip.InstallmentsService.Entity.Dto
{
    /// <summary>
    /// Data structure which defines all the properties for a PaymentPlan Requests.
    /// </summary>
    public class PaymentPlanDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public decimal PurchaseAmount { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int NoOfInstallments { get; set; }
        public int FrequencyInDays { get; set; }
        public PaymentPlanFrequencyTypeEnum FrequencyType { get; set; }
        public List<InstallmentDto> Installments { get; set; }

    }

}
