using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zip.InstallmentsService.Entity.Dto;

namespace Zip.InstallmentsService.Core.Interface
{
    public interface IPaymentPlanProvider
    {
        ValidateRequestDto ValidateCreateRequest(CreatePaymentPlanDto requestModel);
        PaymentPlanDto Create(CreatePaymentPlanDto requestModel);
        PaymentPlanDto GetById(Guid id);

    }
}
