using System;
using System.Collections.Generic;
using System.Text;
using Zip.InstallmentsService.Data.Models;
using Zip.InstallmentsService.Entity;
using Zip.InstallmentsService.Entity.Dto;

namespace Zip.InstallmentsService.Data.Interface
{
    public interface IPaymentPlanRepository
    {
        PaymentPlan Create(PaymentPlanDto requestModel);
        PaymentPlan Get(int id);
    }
}
