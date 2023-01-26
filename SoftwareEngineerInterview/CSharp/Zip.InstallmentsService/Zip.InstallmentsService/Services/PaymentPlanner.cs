using System;
using System.Collections.Generic;
using System.Linq;
using Zip.InstallmentsService.DomainObjects;
using Zip.InstallmentsService.Interface;

namespace Zip.InstallmentsService.Services
{
    /// <summary>
    /// IPaymentPlanner, Generate payment plan based on noOfInstalments, frequencyInWeeks for the purchase amount
    /// </summary>
    public class PaymentPlanner : IPaymentPlanner
    {
        private readonly decimal _purchaseAmount;

        /// <summary>
        /// Constructor: Create a IPaymentPlanner instance with a total amount for the purchase 
        /// </summary>
        /// <param name="purchaseAmount"></param>
        public PaymentPlanner(decimal purchaseAmount)
        {
            if (purchaseAmount < 1)
                throw new ArgumentException($"Minimum purchase amount must be multiple of 1. ", nameof(purchaseAmount));

            _purchaseAmount = purchaseAmount;
        }

        /// <summary>
        /// Get a Payment plan based on noOfInstalments and frequencyInWeeks
        /// </summary>
        /// <param name="noOfInstalments">noOfInstalments</param>
        /// <param name="frequencyInWeeks">frequencyInWeeks</param>
        /// <returns>list of installments details</returns>
        public IEnumerable<Installment> GetPaymentPlan(int noOfInstalments, int frequencyInWeeks)
        {
            if(_purchaseAmount < 1 || noOfInstalments < 1 || frequencyInWeeks <1)
                throw new ArgumentException($"{nameof(_purchaseAmount)}, {nameof(noOfInstalments)} and {nameof(frequencyInWeeks)} must be multiple of 1. ");

            DateTime startDate = DateTime.Now;
            decimal installmentAmount = _purchaseAmount / noOfInstalments;

            foreach (var installment in Enumerable.Range(0, noOfInstalments))
            {
                Installment installmentSchedule = new Installment()
                {
                    Id = Guid.NewGuid(),
                    Amount = installmentAmount,
                    DueDate = startDate,
                };

                yield return installmentSchedule;

                startDate = startDate.AddDays(frequencyInWeeks * 7);
            }
        }
    }
}
