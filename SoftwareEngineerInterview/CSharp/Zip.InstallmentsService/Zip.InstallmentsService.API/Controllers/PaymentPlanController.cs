using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Zip.InstallmentsService.Entity.Dto;
using Zip.InstallmentsService.Interface;

namespace Zip.InstallmentsService.API.Controllers
{

    /// <summary>
    /// Controller which defines all the end points for a purchase installment plan.
    /// </summary>
    [ApiController]
    public class PaymentPlanController : ControllerBase
    {

        private readonly IPaymentPlanProvider _paymentPlanProvider;

        /// <summary>
        /// Intialization in Constructor
        /// </summary>
        /// <param name="paymentPlanProvider"></param>
        public PaymentPlanController(IPaymentPlanProvider paymentPlanProvider)
        {
            _paymentPlanProvider = paymentPlanProvider;
        }

        /// <summary>
        /// Api to get payment plan along with installment by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        //[Authorize]
        [Route("api/PaymentPlan/{id}")]
        public ActionResult<PaymentPlanDto> Get(Guid id)
        {
            try
            {
                var result = _paymentPlanProvider.GetById(id);
                if (result == null)
                {
                    return NotFound(new PaymentPlanDto());
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }


        /// <summary>
        /// Api to create payment plan intallments
        /// </summary>
        /// <param name="_requestModel"></param>
        /// <returns></returns>
        [HttpPost]
        //[Authorize]
        [Route("api/PaymentPlan")]
        public ActionResult<PaymentPlanDto> Create(CreatePaymentPlanDto _requestModel)
        {
            try
            {
                _requestModel.Id = Guid.NewGuid();

                if (_requestModel.PurchaseDate == DateTime.MinValue) 
                    _requestModel.PurchaseDate = DateTime.UtcNow;

                //Validate Request
                var validRequestViewModel = _paymentPlanProvider.ValidateCreateRequest(_requestModel);
                if (!validRequestViewModel.IsValid)
                {
                    return BadRequest(validRequestViewModel.Message);
                }

                //Create Plan
                var result = _paymentPlanProvider.Create(_requestModel);
                if (result == null)
                {
                    return NotFound(new PaymentPlanDto());
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


    }



}
