using Zip.InstallmentsService;

namespace InstallmentCalculationAPI.Interface
{
    public interface IGetInstallmentDetails
    {
       public PaymentPlan GetInstallmentSummary(Guid guid);
    }
}
