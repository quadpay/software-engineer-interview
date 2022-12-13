namespace Zip.InstallmentsService.Test
{
    public class PaymentPlanTestBase
    {
        #region Private Variables 

        public Mock<IRepositoryBase<PaymentPlan>> _repository;
        public IMapper _mapper;

        #endregion

        #region Constructor

        /// <summary>
        /// Create instance of <see cref="PaymentPlanTestBase"/>
        /// </summary>
        public PaymentPlanTestBase()
        {
            _repository = new Mock<IRepositoryBase<PaymentPlan>>();

            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new PaymentPlanProfile());
                });

                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }

        #endregion

        #region Public Method

        /// <summary>
        /// Generates <see cref="CreatePaymentPlanRequest"/> based on inputs
        /// </summary>
        /// <param name="purchaseAmount">The purchase amount</param>
        /// <param name="numberOfInstallments">Number of installments</param>
        /// <param name="frequency">Frequency</param>
        /// <returns></returns>
        public CreatePaymentPlanRequest GeneratePaymentPlanRequest(decimal purchaseAmount,
                                                                   int numberOfInstallments,
                                                                   int frequency)
        {
            return new CreatePaymentPlanRequest()
            {
                PurchaseAmount = purchaseAmount,
                NumberOfInstallments = numberOfInstallments,
                Frequency = frequency,
                PurhcaseDate = DateTime.UtcNow
            };
        }

        #endregion
    }
}
