namespace Zip.InstallmentsService.Core.PaymentPlanAggregate.Handler
{
    /// <summary>
    /// Creates query handler for <see cref="GetPaymentPlanByIdQuery"/>
    /// </summary>
    public class GetPaymentPlanByIdQueryHandler : IRequestHandler<GetPaymentPlanByIdQuery, PaymentPlanResponse>
    {
        #region Private Variables

        private readonly ILogger<GetPaymentPlanByIdQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<PaymentPlan> _repository;

        #endregion

        #region Constructor

        /// <summary>
        /// Create instance of <see cref="GetPaymentPlanByIdQueryHandler"/>
        /// </summary>
        /// <param name="repository"><see cref="IRepositoryBase<PaymentPlan>"/></param>
        /// <param name="mapper"><see cref="IMapper"/></param>
        public GetPaymentPlanByIdQueryHandler(IRepositoryBase<PaymentPlan> repository, IMapper mapper, ILogger<GetPaymentPlanByIdQueryHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        #endregion

        #region Public Method

        /// <summary>
        /// Handles get payment plan by Id query
        /// </summary>
        /// <param name="request"><see cref="GetPaymentPlanByIdQuery"/></param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns><see cref="PaymentPlanResponse"/></returns>
        public async Task<PaymentPlanResponse?> Handle(GetPaymentPlanByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Handling {nameof(GetPaymentPlanByIdQuery)}");

            var plan = await _repository.FindByCondition(c => c.Id == request.Id)
                                        .AsNoTracking()
                                        .Include(y => y.Installments)
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync();

            return plan is not null ? _mapper.Map<PaymentPlanResponse>(plan) : default;
        }

        #endregion
    }
}
