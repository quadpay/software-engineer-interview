using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ZipPayment.API.Business.Services;
using ZipPayment.API.Models;

namespace ZipPayment.API.Controllers
{
    /// <summary>
    /// PaymentPlan Controller class resposible to handle payment plan request and response
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    public class PaymentPlanController : ControllerBase
    {
        private readonly ILogger<PaymentPlanController> _logger;
        private readonly IPaymentService _paymentService;

        /// <summary>
        /// Constructor: Initialize PaymentPlanController by logger, paymentService dependencies
        /// </summary>
        /// <param name="logger">Logger instance to log information api request</param>
        /// <param name="paymentService">Payment serive instance to create a payment plan</param>
        /// <exception cref="ArgumentNullException"></exception>
        public PaymentPlanController(ILogger<PaymentPlanController>? logger, IPaymentService? paymentService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _paymentService = paymentService ?? throw new ArgumentNullException(nameof(paymentService));
        }

        /// <summary>
        /// Get payment plan by id
        /// </summary>
        /// <param name="id">unique payment plan id</param>
        /// <returns>payment plan</returns>
        /// <response code="200">Returns requested payment plan for given payment plan id</response>
        [HttpGet("{id}", Name = "GetPaymentPlan")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PaymentPlanDto>> GetPaymentPlan(Guid id)
        {
            _logger.LogInformation($"Getting PaymentPlan details for the paymentPlan id: {id}");

            var paymentPlan = await _paymentService.GetPaymentPlanAsync(id);

            if (paymentPlan == null || paymentPlan.Id == Guid.Empty)
            {
                _logger.LogError($"payment plan with id: {id}, hasn't been found in db.");
                return NotFound();
            }

            return Ok(paymentPlan);
        }

        /// <summary>
        /// Get all payment plans
        /// </summary>
        /// <returns>List of all payment plans</returns>
        /// <response code="200">All payment plans</response>
        [HttpGet(Name = "GetAllPaymentPlan")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<PaymentPlanDto>>> GetPaymentPlans()
        {
            _logger.LogInformation($"Getting all payment plans details.");

            var paymentPlans = await _paymentService.GetAllPaymentPlansAsync();
            return Ok(paymentPlans);
        }

        /// <summary>
        /// Create a new payment plan with installments schedule
        /// </summary>
        /// <param name="amount">purchase amount</param>
        /// <param name="noOfInstalments">no of installments</param>
        /// <param name="frequencyInWeeks">frequency of payment in week</param>
        /// <returns>Created Payment plan with installment details</returns>
        [HttpPost("{amount:decimal}/{noOfInstalments:int}/{frequencyInWeeks:int}", Name = "CreatePaymentPlan")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PaymentPlanDto>> CreatePaymentPlan(decimal amount, int noOfInstalments, int frequencyInWeeks)
        {


            if (amount <= 0 || noOfInstalments <= 0 || frequencyInWeeks <= 0)
            {
                _logger.LogError("invalid input parameters check purchase amount, noOfInstalments or frequencyInWeeks ");
                return BadRequest();
            }

            _logger.LogInformation($"Create a new payment plan.");
            PaymentPlanDto? newPaymentPlan = await _paymentService.CreatePaymentPlan(amount, noOfInstalments, frequencyInWeeks);

            if (newPaymentPlan == null)
            {
                _logger.LogError($"unable to save payment plan details in db.");
                return NoContent();
            }

            return CreatedAtRoute("GetPaymentPlan", new { id = newPaymentPlan.Id }, newPaymentPlan);
        }

        #region Link creation
        private IEnumerable<LinkDto> CreateLinksForPaymentPlan(Guid paymentPlanId, string? fields)
        {
            var links = new List<LinkDto>();

            links.Add(new(Url.Link("GetPaymentPlan", new { paymentPlanId }), "self","GET"));
            links.Add(new(Url.Link("CreatePaymentPlan", new { paymentPlanId }), "create_payment_plan", "POST"));
            links.Add(new(Url.Link("GetAllPaymentPlan", string.Empty), "all", "GET"));
            return links;
        }
        #endregion
    }
}
