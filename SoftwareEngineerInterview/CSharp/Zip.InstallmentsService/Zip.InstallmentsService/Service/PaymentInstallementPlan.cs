namespace Zip.InstallmentsService.Service
{
    using Microsoft.VisualBasic;
    using System;
    using Zip.Installements.Contract.Request;
    using Zip.Installements.Domain.Entities;
    using Zip.InstallmentsService.Interface;

    public class PaymentInstallementPlan : IPaymentInstallementPlan
    {
        public Payment CreatePaymentPlan(PaymentPlanRequest paymentPlanRequest)
        {
            var payment = new Payment();
            payment.Amount = paymentPlanRequest.Amount;
            var installementAmount = paymentPlanRequest.Amount / paymentPlanRequest.NumofInstallement;

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
