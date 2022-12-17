using Zip.InstallmentsService;

namespace InstallmentCalculationAPI.Interface
{
    public interface IInstallmentCalculator
    {
        PaymentPlan CalculateInstallment(InstallmentRequest installmentRequest);
    }
}
