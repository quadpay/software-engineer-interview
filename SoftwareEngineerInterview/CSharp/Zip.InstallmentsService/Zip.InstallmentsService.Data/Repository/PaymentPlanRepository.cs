using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Zip.InstallmentsService.Data.Interface;
using Zip.InstallmentsService.Data.Models;
using Zip.InstallmentsService.Entity.Dto;

namespace Zip.InstallmentsService.Data.Repository
{
    public class PaymentPlanRepository : IPaymentPlanRepository
    {
        private readonly ApiContext _context;

        /// <summary>
        /// Intialization in Constructor 
        /// </summary>
        /// <param name="context"></param>
        public PaymentPlanRepository(ApiContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Database logic to get payment plan by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PaymentPlan GetById(Guid id)
        {
            var result = _context.PaymentPlans.Where(k => k.Id == id).Include(k => k.Installments)?.FirstOrDefault();
            return result;
        }

        /// <summary>
        /// Database logic to create payment plan
        /// </summary>
        /// <param name="_paymentPlan"></param>
        /// <returns></returns>
        public PaymentPlan Create(PaymentPlanDto _paymentPlan)
        {
            var paymenPlan = new PaymentPlan
            {
                Id = _paymentPlan.Id,
                UserId = _paymentPlan.UserId,
                PurchaseAmount = _paymentPlan.PurchaseAmount,
                PurchaseDate = _paymentPlan.PurchaseDate,
                NoOfInstallments = _paymentPlan.NoOfInstallments,
                FrequencyInDays = _paymentPlan.FrequencyInDays,
                CreatedOn = DateTime.UtcNow,
                CreatedBy = _paymentPlan.UserId
            };
            _context.PaymentPlans.Add(paymenPlan);

            foreach (var item in _paymentPlan?.Installments)
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


    }
}
