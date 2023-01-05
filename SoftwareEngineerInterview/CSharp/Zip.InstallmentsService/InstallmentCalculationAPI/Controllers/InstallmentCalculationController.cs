using InstallmentCalculationAPI.Interface;
using InstallmentCalculationAPI.Log;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;
using Zip.InstallmentsService;

namespace InstallmentCalculationAPI.Controllers
{
    /// <summary>
    /// Controller for creating payment plan, storing into DB and fetching it from DB
    /// </summary>
    [ApiController]
    public class InstallmentCalculationController : ControllerBase
    {
        /// <summary>
        /// Declare claculator object to be used to pass request
        /// </summary>
        private readonly IInstallmentCalculator _installmentCalculator;
        private ILog _logger;
        /// <summary>
        /// Initialize calculator object
        /// </summary>
        /// <param name="installmentCalculator"></param>
        public InstallmentCalculationController(IInstallmentCalculator installmentCalculator,ILog logger)
        {
            _installmentCalculator = installmentCalculator;
            _logger = logger;
        }
        /// <summary>
        /// Action method to create payment plan
        /// </summary>
        /// <param name="installmentRequest">input request contains purchase amount, purchase date, installment and installmemt frequency</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/v{version:apiVersion}/[controller]")]
        [ApiVersion("1.0")]
        public InstallmentResponse CreatePaymentPlan([FromBody] InstallmentRequest installmentRequest)
        {
            InstallmentResponse installmentResponse = new InstallmentResponse();
                if (ModelState.IsValid)
                {
                    //Make a call to installment calculator service  
                    installmentResponse.PaymentPlan = _installmentCalculator.CalculateInstallment(installmentRequest);
                    installmentResponse.ResponseMessage = "Installment Calculated and stored successfully.";
                    installmentResponse.StatusCode = StatusCodes.Status200OK;
                    installmentResponse.Status = true;
                    _logger.Information("Installment Calculated successfully and stored into Db for ID: " + installmentResponse.PaymentPlan.Id +" "+"TimeStamp: "+DateTime.Now);
                }
            return installmentResponse;
        }

        /// <summary>
        /// Action method to fetch Payment plan based on id
        /// </summary>
        /// <param name="guid">unique identifier for each payment plan</param>
        /// <returns>Payment plan with instalment details</returns>
        [HttpGet]
        [Route("api/v{version:apiVersion}/[controller]")]
        [ApiVersion("1.0")]
        public InstallmentResponse GetInstallmentSummary(Guid guid)
        {
            InstallmentResponse installmentResponse = new InstallmentResponse();
            
                if (ModelState.IsValid)
                {
                    //Make a call to Installment calculator service to fetch payment details
                    installmentResponse.PaymentPlan = _installmentCalculator.GetInstallmentSummary(guid);
                    if (installmentResponse.PaymentPlan != null)
                    {
                        installmentResponse.ResponseMessage = "Payment plan fetched successfully.";
                        installmentResponse.StatusCode = StatusCodes.Status200OK;
                        installmentResponse.Status = true;
                        _logger.Information("Payment plan fetched successfully for ID: " + guid + " " + "TimeStamp: " + DateTime.Now);
                    }
                    else
                    {
                        installmentResponse.ResponseMessage = "Payment plan could not found.";
                        installmentResponse.StatusCode = StatusCodes.Status204NoContent;
                        installmentResponse.Status = false;
                        _logger.Warning("Payment plan could not found for ID: " + guid + " " + "TimeStamp: " + DateTime.Now);
                    }
                    
                }
            return installmentResponse;
        }
    }
}
