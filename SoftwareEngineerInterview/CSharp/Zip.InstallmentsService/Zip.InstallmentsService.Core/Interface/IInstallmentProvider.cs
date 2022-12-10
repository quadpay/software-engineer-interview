using System;
using System.Collections.Generic;
using System.Text;
using Zip.InstallmentsService.Entity.Dto;

namespace Zip.InstallmentsService.Core.Interface
{
    public interface IInstallmentProvider
    {
        List<InstallmentDto>  CalculateInstallments(PaymentPlanDto requestModel);
    }
}
