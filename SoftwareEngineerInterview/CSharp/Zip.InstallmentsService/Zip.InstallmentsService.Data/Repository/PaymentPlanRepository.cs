using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;
using Zip.InstallmentsService.Data.Interface;
using Zip.InstallmentsService.Data.Models;
using Zip.InstallmentsService.Entity.Dto;

namespace Zip.InstallmentsService.Data.Repository
{
    public class PaymentPlanRepository : IPaymentPlanRepository
    {
        private readonly ApiContext _context;

        public PaymentPlanRepository(ApiContext context)
        {
            _context = context;
        }

        public PaymentPlan Create(PaymentPlanDto _paymentPlan)
        {
            var paymenPlan = new PaymentPlan
            {
                Id = _paymentPlan.Id,
                UserId = _paymentPlan.UserId,
                PurchaseAmount = _paymentPlan.PurchaseAmount,
                PurchaseDate = _paymentPlan.PurchaseDate,
                NoOfInstallments = _paymentPlan.NoOfInstallments,
                Frequency = _paymentPlan.FrequencyInDays
            };
            _context.PaymentPlans.Add(paymenPlan);

            foreach (var item in paymenPlan.Installments)
            {
                var installment = new Installment
                {
                    Id = item.Id,
                    PaymentPlanId = item.PaymentPlanId,
                    DueDate = item.DueDate,
                    Amount = item.Amount,
                    CreatedOn = item.CreatedOn,
                    CreatedBy = item.CreatedBy
                };
                _context.Installments.Add(installment);
            }

            _context.SaveChanges();
            return paymenPlan;
        }

        public PaymentPlan Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
