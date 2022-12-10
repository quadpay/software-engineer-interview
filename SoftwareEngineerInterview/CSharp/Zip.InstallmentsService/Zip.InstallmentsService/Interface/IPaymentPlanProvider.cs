using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zip.InstallmentsService.Entity.Request;
using Zip.InstallmentsService.Entity.Response;

namespace Zip.InstallmentsService.Interface
{
    public interface IPaymentPlanProvider
    {
        ValidateResponseModel ValidatePaymentPlanCreateRequest(CreatePaymentPlanRequestModel requestModel);
        PaymentPlanResponseModel Create(CreatePaymentPlanRequestModel requestModel);
        PaymentPlanResponseModel Get(int id);

    }
}
