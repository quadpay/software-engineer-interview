using Zip.InstallmentsService;

namespace InstallmentCalculationAPI.Interface
{
    /// <summary>
    /// Interface for business logic to calculate and fetch payment plan
    /// </summary>
    public interface IInstallmentCalculator
    {
        PaymentPlan? CalculateInstallment(InstallmentRequest installmentRequest);
        PaymentPlan? GetInstallmentSummary(Guid guid);
    }
}
