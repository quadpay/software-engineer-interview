using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zip.InstallmentsService.Dto;
using Zip.InstallmentsService.Infrastructure.Interfaces;

namespace Zip.InstallmentsService.Infrastructure.Services
{
    public class PaymentPlanService : IPaymentPlanService
    {
        private IPaymentPlanRepository _paymentPlanRepository;      

        public PaymentPlanService(IPaymentPlanRepository paymentPlanRepository)
        {
            _paymentPlanRepository = paymentPlanRepository;
        }       

        public Task<IEnumerable<Installment>> CreatePaymentPlan(PaymentPlan paymentPlan)
        {
           return _paymentPlanRepository.CreatePaymentPlan(paymentPlan);
        }
    }
}
