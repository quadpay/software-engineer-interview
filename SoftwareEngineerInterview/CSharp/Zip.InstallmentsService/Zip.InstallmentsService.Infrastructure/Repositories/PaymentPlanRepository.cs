using Microsoft.EntityFrameworkCore;
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
     
        public async Task<IEnumerable<Installment>> CreatePaymentPlan(PaymentPlan paymentPlan)
        {
            decimal amount = paymentPlan.PurchaseAmount / paymentPlan.Installments;
            List<Installment> list = new List<Installment>();
            DateTime dueDate= DateTime.Now;
            int i = 1;
            while (i <= paymentPlan.Installments)
            {
                if (i == 1)
                    dueDate = dueDate.AddDays(paymentPlan.FrequencyInDays);
                else
                    dueDate = dueDate.AddDays(paymentPlan.FrequencyInDays);
               // list.Add(new Installment() { PaymentPlanId = paymentPlan.PaymentPlanId, DueDate = dueDate, Amount = amount });
                Installment lst = new Installment();
                lst.PaymentPlanId = paymentPlan.PaymentPlanId;
                lst.DueDate = dueDate;
                lst.Amount = amount;
                _Context.installment.Add(lst);
               _Context.SaveChanges();
                i++;
            }
            await Task.CompletedTask;
            var insertlist = from x in _Context.installment where x.PaymentPlanId==paymentPlan.PaymentPlanId  select new Installment {ID=x.ID, PaymentPlanId=x.PaymentPlanId, DueDate=x.DueDate, Amount=x.Amount };
            return insertlist;
        }
    }
}
