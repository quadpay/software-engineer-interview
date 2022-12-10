using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zip.InstallmentsService.Entity.Dto;

namespace Zip.InstallmentsService.Interface
{
    public interface IPaymentPlanProvider
    {
        ValidateRequestDto ValidateCreateRequest(PaymentPlanDto requestModel);
        PaymentPlanDto Create(PaymentPlanDto requestModel);
        PaymentPlanDto Get(int id);

    }
}
