namespace Zip.InstallmentsService.Core.PaymentPlanAggregate.Handler
{
    /// <summary>
    /// Provides command handler for <see cref="CreatePaymentPlanCommand"/>
    /// </summary>
    public class CreatePaymentPlanCommandHandler : IRequestHandler<CreatePaymentPlanCommand, PaymentPlanResponse>
    {
        #region Private Variables

        private readonly ILogger<CreatePaymentPlanCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<PaymentPlan> _repository;

        #endregion


        #region Constructor

        /// <summary>
        /// Creates object of <see cref="CreatePaymentPlanCommandHandler"/>
        /// </summary>
        /// <param name="repository"><see cref="IRepositoryBase<PaymentPlan> "/></param>
        /// <param name="mapper"><see cref="IMapper"/></param>
        public CreatePaymentPlanCommandHandler(IRepositoryBase<PaymentPlan> repository, IMapper mapper, ILogger<CreatePaymentPlanCommandHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        #endregion

        #region Public Method

        /// <summary>
        /// Handles the <see cref="CreatePaymentPlanCommand"/> request
        /// </summary>
        /// <param name="request"><see cref="CreatePaymentPlanCommand"/></param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns><see cref="PaymentPlanResponse"/></returns>
        public async Task<PaymentPlanResponse> Handle(CreatePaymentPlanCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Handling {nameof(CreatePaymentPlanCommand)}");

            var planRequest = request.PlanRequest;

            var createdPlan = new PaymentPlan(planRequest.PurchaseAmount);

            createdPlan.CreatePaymentPlan(planRequest.PurhcaseDate, planRequest.NumberOfInstallments, planRequest.Frequency);

            await _repository.CreateAsync(createdPlan);

            return _mapper.Map<PaymentPlan, PaymentPlanResponse>(createdPlan);
        }

        #endregion
    }
}
