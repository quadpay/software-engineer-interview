namespace Zip.InstallmentsService.Test
{
    public class GetPaymentPlanQueryTests : PaymentPlanTestBase
    {
        #region Private Variables 

        private GetPaymentPlanByIdQueryHandler _getPaymentPlanByIdQueryHandler;
        public Mock<ILogger<GetPaymentPlanByIdQueryHandler>> _logger;

        #endregion

        #region Constructor

        /// <summary>
        /// Create instance of <see cref="GetPaymentPlanQueryTests"/>
        /// </summary>
        public GetPaymentPlanQueryTests() : base()
        {
            _logger = new Mock<ILogger<GetPaymentPlanByIdQueryHandler>>();
            _getPaymentPlanByIdQueryHandler = new GetPaymentPlanByIdQueryHandler(_repository.Object, _mapper, _logger.Object);

            var paymentPlans = new List<PaymentPlan>()
            {
                new PaymentPlan()
                {
                    Id=new Guid("910850e1-49c5-4331-a7ce-3d6c7fc25547"),
                    PurchaseAmount=100,
                    CreatedOnUtc=DateTime.Now,
                    Installments=new List<Installment>()
                    {
                        new Installment()
                        {
                            Id=Guid.NewGuid(),
                            Amount=25,
                            CreatedOnUtc=DateTime.Now,
                            DueDate=DateTime.Now
                        },
                        new Installment()
                        {
                            Id=Guid.NewGuid(),
                            Amount=25,
                            CreatedOnUtc=DateTime.Now,
                            DueDate=DateTime.Now.AddDays(14)
                        },
                        new Installment()
                        {
                            Id=Guid.NewGuid(),
                            Amount=25,
                            CreatedOnUtc=DateTime.Now,
                            DueDate=DateTime.Now.AddDays(28)
                        },
                        new Installment()
                        {
                            Id=Guid.NewGuid(),
                            Amount=25,
                            CreatedOnUtc=DateTime.Now,
                            DueDate=DateTime.Now.AddDays(42)
                        }
                    }
                }
            };


            _repository.Setup(x => x.FindByCondition(It.IsAny<Expression<Func<PaymentPlan, bool>>>())).Returns(paymentPlans.AsQueryable().BuildMock());
        }

        #endregion

        #region Tests

        /// <summary>
        /// Test case used to validate successful scenarios of <see cref="GetPaymentPlanByIdQuery"/>
        /// </summary>
        [Fact]
        public async Task GetPaymentPlanByIdQuery_Successful()
        {
            GetPaymentPlanByIdQuery query = new(new Guid("910850e1-49c5-4331-a7ce-3d6c7fc25547"));

            var result = await _getPaymentPlanByIdQueryHandler.Handle(query, CancellationToken.None);

            Assert.NotNull(result);
            Assert.True(result.PurchaseAmount == 100);
            Assert.True(result.Installments.Count == 4);

            result.Installments.ForEach(installment =>
            {
                Assert.True(installment.Amount == 25);
            });
        }

        #endregion
    }
}
