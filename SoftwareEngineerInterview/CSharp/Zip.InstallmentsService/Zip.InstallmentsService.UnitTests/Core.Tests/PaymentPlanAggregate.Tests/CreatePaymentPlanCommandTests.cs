namespace Zip.InstallmentsService.Test
{
    public class CreatePaymentPlanCommandTests : PaymentPlanTestBase
    {
        #region Private Variables 

        private CreatePaymentPlanCommandHandler _handler;
        public Mock<ILogger<CreatePaymentPlanCommandHandler>> _logger;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates instance of <see cref="CreatePaymentPlanCommandTests"/>
        /// </summary>
        public CreatePaymentPlanCommandTests() : base()
        {
            _logger = new Mock<ILogger<CreatePaymentPlanCommandHandler>>();
            _handler = new CreatePaymentPlanCommandHandler(_repository.Object, _mapper, _logger.Object);
        }

        #endregion

        #region Tests

        /// <summary>
        /// Test used to validate successful scenario's of <see cref="CreatePaymentPlanCommand"/>
        /// </summary>
        /// <param name="purchaseAmount">The purchase amount</param>
        /// <param name="numberOfInstallments">Number of installments</param>
        /// <param name="frequency">Frequency</param>
        /// <param name="installmentAmount">Installment amount</param>
        [Theory]
        [InlineData(2000, 4, 14, 500.00)]
        [InlineData(25, 4, 14, 6.25)]
        [InlineData(82, 3, 14, 27.33)]
        [InlineData(487, 3, 30, 162.33)]
        public async Task CreatePaymentPlan_Successful(decimal purchaseAmount,
                                                       int numberOfInstallments,
                                                       int frequency,
                                                       decimal installmentAmount)
        {
            var request = GeneratePaymentPlanRequest(purchaseAmount, numberOfInstallments, frequency);

            CreatePaymentPlanCommand command = new(request);

            var paymentPlan = await _handler.Handle(command, CancellationToken.None);

            Assert.NotNull(paymentPlan);
            Assert.True(paymentPlan.PurchaseAmount == purchaseAmount);
            Assert.True(paymentPlan.Installments.Count == numberOfInstallments);

            paymentPlan.Installments.ForEach(installment =>
            {
                Assert.True(installment.Amount == installmentAmount);
            });
        }

        /// <summary>
        /// Test used to validate unsuccessful scenario's of <see cref="CreatePaymentPlanCommand"/>
        /// </summary>
        /// <param name="purchaseAmount">The purchase amount</param>
        /// <param name="numberOfInstallments">Number of installments</param>
        /// <param name="frequency">Frequency</param>
        [Theory]
        [InlineData(0, 4, 14)]
        [InlineData(25, 0, 14)]
        [InlineData(82, 3, 0)]
        public async Task CreatePaymentPlan_UnSuccessful(decimal purchaseAmount,
                                                         int numberOfInstallments,
                                                         int frequency)
        {
            var request = GeneratePaymentPlanRequest(purchaseAmount, numberOfInstallments, frequency);

            CreatePaymentPlanCommand command = new(request);

            var paymentPlan = await _handler.Handle(command, CancellationToken.None);

            Assert.NotNull(paymentPlan);
            Assert.True(paymentPlan.Installments.Count == 0);
        }

        #endregion
    }
}
