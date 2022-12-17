using InstallmentCalculationAPI.BusinessLogic;
using InstallmentCalculationAPI.Interface;
using Microsoft.AspNetCore.Mvc;
using Zip.InstallmentsService;

namespace InstallmentCalculationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InstallmentCalculationController : ControllerBase
    {
        private readonly IInstallmentCalculator _installmentCalculator;
        private readonly IGetInstallmentDetails _getInstallmentDetails;
        public InstallmentCalculationController(IInstallmentCalculator installmentCalculator,IGetInstallmentDetails getInstallmentDetails)
        {
            _installmentCalculator = installmentCalculator;
            _getInstallmentDetails = getInstallmentDetails;
        }
        [HttpPost]
        [Route("CreatePaymentPlan")]
        public InstallmentResponse CreatePaymentPlan(InstallmentRequest installmentRequest)
        {
            InstallmentResponse installmentResponse = new InstallmentResponse();
            bool status = false;
            try
            {
                //InstallmentCalculator installmentCalculator = new InstallmentCalculator();
                installmentResponse.PaymentPlan = _installmentCalculator.CalculateInstallment(installmentRequest);
                installmentResponse.ResponseMessage = "Installment Calculated and stored successfully.";
            }
            catch (Exception ex)
            {

                installmentResponse.ResponseMessage = "Error occured during installment calculation." +" Error Message: "+ex.Message + "Stack Trace: "+ex.StackTrace;
            }
            return installmentResponse;
        }

        [HttpGet]
        [Route("GetInstallmentSummary")]
        public PaymentPlan GetInstallmentSummary(Guid guid)
        {
            PaymentPlan paymentPlan = new PaymentPlan();
            try
            {
                paymentPlan = _getInstallmentDetails.GetInstallmentSummary(guid);
            }
            catch (Exception ex)
            {

                throw;
            }
            return paymentPlan;
        }
    }
}
