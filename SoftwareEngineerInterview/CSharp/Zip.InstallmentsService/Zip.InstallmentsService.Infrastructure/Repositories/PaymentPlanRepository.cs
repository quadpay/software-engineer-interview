using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zip.InstallmentsService.Dto;
using Zip.InstallmentsService.Infrastructure.DBContext;
using Zip.InstallmentsService.Infrastructure.Interfaces;

namespace Zip.InstallmentsService.Infrastructure.Repositories
{
    public class PaymentPlanRepository : IPaymentPlanRepository
    {
        private readonly PaymentPlanDBContext _Context;

        public PaymentPlanRepository(PaymentPlanDBContext Context)
        {
            _Context = Context;
        }
        public Task<IEnumerable<Installment>> CreatePaymentPlan(PaymentPlan paymentPlan)
        {

            

            throw new NotImplementedException();
        }
    }
}
