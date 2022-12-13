namespace Zip.InstallmentsService.Web.Controllers
{
    /// <summary>
    /// Produces Api for creating installment plan and getting installment plan
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    public class PaymentPlanController : ControllerBase
    {
        #region Private Variables

        private readonly ILogger<PaymentPlanController> _logger;
        private readonly IMediator _mediator;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates instance of <see cref="PaymentPlanController"/>
        /// </summary>
        /// <param name="mediator"><see cref="IMediator"/></param>
        /// <param name="logger"><see cref="ILogger<PaymentPlanController>"/></param>
        public PaymentPlanController(IMediator mediator, ILogger<PaymentPlanController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates payment/installment plan based on input provided
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/v1/paymentplan
        ///     {
        ///         "purchaseAmount": 100,
        ///         "purhcaseDate": "2022-12-08T09:56:51.958Z",
        ///         "numberOfInstallments": 4,
        ///         "frequency": 14
        ///     }
        /// </remarks>
        /// <param name="request"></param>
        /// <returns><see cref="PaymentPlanResponse"/></returns>
        [HttpPost]
        [ProducesResponseType(typeof(PaymentPlanResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreatePaymentPlan([FromBody] CreatePaymentPlanRequest request)
        {
            _logger.LogInformation($"Creating payment plan.");
            _logger.LogDebug($"Payment Plan Request: {request.ToString()}");

            CreatePaymentPlanCommand command = new(request);

            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(CreatePaymentPlan), result);
        }

        /// <summary>
        /// Retrives payment/installment plan based on id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET api/v1/paymentplan/73f5592b-698e-41db-9d8e-3f97986255f6
        /// </remarks>
        /// <param name="id"></param>
        /// <returns><see cref="PaymentPlanResponse"/></returns>
        [HttpGet("id/{id}")]
        [ProducesResponseType(typeof(PaymentPlanResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPaymentPlan([FromRoute] Guid id)
        {
            _logger.LogInformation($"Fetching payment plan.");
            _logger.LogDebug($"Payment Plan Id: {id}");

            GetPaymentPlanByIdQuery getPaymentPlanByIdQuery = new(id);

            var result = await _mediator.Send(getPaymentPlanByIdQuery);

            return result is null ? NotFound() : Ok(result);
        }

        #endregion
    }
}
