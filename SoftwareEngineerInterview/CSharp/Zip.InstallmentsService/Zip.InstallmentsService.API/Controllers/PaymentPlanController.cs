using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using Zip.InstallmentsService.Entity.Dto;
using Zip.InstallmentsService.Core.Interface;

namespace Zip.InstallmentsService.API.Controllers
{

    /// <summary>
    /// Controller which defines all the end points for a purchase installment plan.
    /// </summary>
    [ApiController]
    public class PaymentPlanController : ControllerBase
    {

        private readonly IPaymentPlanProvider _paymentPlanProvider;
        private readonly ILogger _logger;

        /// <summary>
        /// Intialization in Constructor
        /// </summary>
        /// <param name="paymentPlanProvider"></param>
        /// <param name="_logger"></param>
        public PaymentPlanController(IPaymentPlanProvider paymentPlanProvider, ILogger logger)
        {
            _paymentPlanProvider = paymentPlanProvider;
            _logger = logger;
        }

        /// <summary>
        /// Api to get payment plan along with installment by id
        ///  UnComment or add Authorize for JWT token based authentication
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
                
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }


        /// <summary>
        /// Api to create payment plan intallments
        ///  UnComment or add Authorize for JWT token based authentication
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
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }



    }



}
