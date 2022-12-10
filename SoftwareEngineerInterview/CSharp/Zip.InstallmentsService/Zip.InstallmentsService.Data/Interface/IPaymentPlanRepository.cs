using System;
using System.Collections.Generic;
using System.Text;
using Zip.InstallmentsService.Entity.Request;
using Zip.InstallmentsService.Entity.Response;

namespace Zip.InstallmentsService.Data.Interface
{
    public interface IPaymentPlanRepository
    {
        PaymentPlanResponseModel Create(CreatePaymentPlanRequestModel requestModel);
        PaymentPlanResponseModel Get(int id);
    }
}
