namespace Zip.InstallmentsService.Test
{
    public class PaymentPlanControllerTests : PaymentPlanTestBase
    {
        #region Private Variables 

        private Mock<ILogger<PaymentPlanController>> _logger;
        private Mock<IMediator> _mediator;
        private PaymentPlanController _paymentPlanController;

        #endregion

        #region Constructor

        /// <summary>
        /// Used to create instance of <see cref="PaymentPlanControllerTests"/>
        /// </summary>
        public PaymentPlanControllerTests()
        {
            _mediator = new Mock<IMediator>();
            _logger = new Mock<ILogger<PaymentPlanController>>();
            _paymentPlanController = new PaymentPlanController(_mediator.Object, _logger.Object);
        }

        #endregion

        #region Tests

        /// <summary>
        /// Test used to validate payment plan is created successfully
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
        public async Task PaymentPlanController_CreatePaymentPlan_Successful(decimal purchaseAmount,
                                                                             int numberOfInstallments,
                                                                             int frequency,
                                                                             decimal installmentAmount)
        {
            var request = GeneratePaymentPlanRequest(purchaseAmount, numberOfInstallments, frequency);

            var expected = new PaymentPlanResponse()
            {
                PaymentPlanId = Guid.NewGuid(),
                PurchaseAmount = purchaseAmount,
                Installments = Enumerable.Range(0, numberOfInstallments).Select(i => new InstallmentResponse()
                {
                    InstallmentId = Guid.NewGuid(),
                    Amount = installmentAmount,
                    DueDate = DateTime.Now.AddDays(i * frequency).ToString("MMM dd, yyyy")
                }).ToList()
            };

            _mediator.Setup(m => m.Send(It.IsAny<CreatePaymentPlanCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(expected);

            var result = await _paymentPlanController.CreatePaymentPlan(request);
            var paymentPlan = ((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value as PaymentPlanResponse;

            Assert.NotNull(paymentPlan);
            Assert.True(paymentPlan.PurchaseAmount == purchaseAmount);
            Assert.True(paymentPlan.Installments.Count == numberOfInstallments);

            paymentPlan.Installments.ForEach(installment =>
            {
                Assert.True(installment.Amount == installmentAmount);
            });
        }

        /// <summary>
        /// Test used to validate GetPaymentPlan
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
        public async Task PaymentPlanController_GetPaymentPlan_Successful(decimal purchaseAmount,
                                                                          int numberOfInstallments,
                                                                          int frequency,
                                                                          decimal installmentAmount)
        {
            var request = Guid.NewGuid();

            var expected = new PaymentPlanResponse()
            {
                PaymentPlanId = Guid.NewGuid(),
                PurchaseAmount = purchaseAmount,
                Installments = Enumerable.Range(0, numberOfInstallments).Select(i => new InstallmentResponse()
                {
                    InstallmentId = Guid.NewGuid(),
                    Amount = installmentAmount,
                    DueDate = DateTime.Now.AddDays(i * frequency).ToString("MMM dd, yyyy")
                }).ToList()
            };

            _mediator.Setup(m => m.Send(It.IsAny<GetPaymentPlanByIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(expected);

            var result = await _paymentPlanController.GetPaymentPlan(request);
            var paymentPlan = ((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value as PaymentPlanResponse;

            Assert.NotNull(paymentPlan);
            Assert.True(paymentPlan.PurchaseAmount == purchaseAmount);
            Assert.True(paymentPlan.Installments.Count == numberOfInstallments);

            paymentPlan.Installments.ForEach(installment =>
            {
                Assert.True(installment.Amount == installmentAmount);
            });
        }

        #endregion
        
    }
}
