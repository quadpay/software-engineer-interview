using System;
using System.Collections.Generic;
using System.Text;
using Zip.InstallmentsService.Entity.Dto;

namespace Zip.InstallmentsService.Interface
{
    public interface IInstallmentProvider
    {
        IEnumerable<InstallmentDto>  CalculateInstallments(PaymentPlanDto requestModel);
    }
}
