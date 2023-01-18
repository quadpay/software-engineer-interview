namespace Zip.InstallmentsService.Service
{
    using System;
    using Zip.Installments.Common;
    using Zip.Installments.Contract.Request;
    using Zip.Installments.Domain.Entities;
    using Zip.InstallmentsService.Interface;

    /// <summary>
    /// Class implements the method to create payment installment plan
    /// </summary>
    public class PaymentInstallmentPlan : IPaymentInstallementPlan
    {
        /// <summary>
        /// Method to create payment installement plan.
        /// </summary>
        /// <param name="paymentPlanRequest">Model contains data to create installement plan.</param>
        /// <returns>Returns payment installement plan.</returns>
        public Payment CreatePaymentPlan(PaymentPlanRequest paymentPlanRequest)
        {
            if (paymentPlanRequest.Amount <= 0)
            {
                return null;
            }

            var payment = new Payment();
            payment.Amount = paymentPlanRequest.Amount;

            var installementAmount = Math.Round(paymentPlanRequest.Amount / paymentPlanRequest.NumofInstallement,
                Constants.RoundOffValue,
                MidpointRounding.ToEven);

            for (var cnt = 0; cnt < paymentPlanRequest.NumofInstallement; cnt++)
            {
                payment.InstallmentPlans.Add(new InstallmentPlan()
                {
                    DueAmount = installementAmount,
                    DueDate = cnt == 0 ? DateTimeOffset.UtcNow : DateTimeOffset.UtcNow.AddDays(paymentPlanRequest.Frequency * cnt)
                });
            }

            return payment;
        }
    }
}
