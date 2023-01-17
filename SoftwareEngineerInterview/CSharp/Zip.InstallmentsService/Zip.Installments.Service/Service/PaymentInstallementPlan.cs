namespace Zip.InstallmentsService.Service
{
    using System;
    using Zip.Installements.Common;
    using Zip.Installements.Contract.Request;
    using Zip.Installements.Domain.Entities;
    using Zip.InstallmentsService.Interface;

    /// <summary>
    /// Class implements the method to create payment installement plan
    /// </summary>
    public class PaymentInstallementPlan : IPaymentInstallementPlan
    {
        /// <summary>
        /// Method to create payment installement plan.
        /// </summary>
        /// <param name="paymentPlanRequest">Model contains data to create installement plan.</param>
        /// <returns>Returns payment installement plan.</returns>
        public Payment CreatePaymentPlan(PaymentPlanRequest paymentPlanRequest)
        {
            var payment = new Payment();
            payment.Amount = paymentPlanRequest.Amount;
            var installementAmount = Math.Round(paymentPlanRequest.Amount / paymentPlanRequest.NumofInstallement,
                Constants.RoundOffValue,
                MidpointRounding.ToEven);

            for (var cnt = 0; cnt < paymentPlanRequest.NumofInstallement; cnt++)
            {
                payment.InstallementPlans.Add(new InstallementPlan()
                {
                    DueAmount = installementAmount,
                    DueDate = cnt == 0 ? DateTimeOffset.UtcNow : DateTimeOffset.UtcNow.AddDays(paymentPlanRequest.Frequency * cnt)
                });
            }

            return payment;
        }
    }
}
