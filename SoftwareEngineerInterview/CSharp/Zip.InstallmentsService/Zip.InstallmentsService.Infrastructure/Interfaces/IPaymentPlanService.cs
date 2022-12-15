using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zip.InstallmentsService.Dto;

namespace Zip.InstallmentsService.Infrastructure.Interfaces
{
    public interface IPaymentPlanService
    {
        Task<IEnumerable<Installment>> CreatePaymentPlan(PaymentPlan paymentPlan);

    }
}
