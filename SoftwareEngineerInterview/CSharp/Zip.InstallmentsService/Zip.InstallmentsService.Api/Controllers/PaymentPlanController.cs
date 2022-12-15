using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zip.InstallmentsService.Dto;
using Zip.InstallmentsService.Infrastructure.Interfaces;

namespace Zip.InstallmentsService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentPlanController : ControllerBase
    {
        private readonly IPaymentPlanService _paymentPlanService;

        public PaymentPlanController(IPaymentPlanService paymentPlanService)
        {
            _paymentPlanService = paymentPlanService;
        }       

        [HttpPost]
        [Route("GetInstallments")]
        public async Task<IActionResult> GetInstallments(PaymentPlan paymentPlan)
        {
            if(paymentPlan.PaymentPlanId==null || paymentPlan.PurchaseAmount==0)
            {
               return BadRequest("Please provide Payment Plan");
            }
                    
            var Installments = await _paymentPlanService.CreatePaymentPlan(paymentPlan);
            return new OkObjectResult(Installments);
           
        }
      
    }
}
