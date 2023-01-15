namespace Zip.InstallmentsService.Interface
{
    using Zip.Installements.Contract.Request;
    using Zip.Installements.Domain.Entities;

    public interface IPaymentInstallementPlan
    {
        Payment CreatePaymentPlan(PaymentPlanRequest paymentPlanRequest);
    }
}
