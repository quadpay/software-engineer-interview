using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using ZipPayment.API.Business.Services;
using ZipPayment.API.Controllers;
using ZipPayment.API.Models;
using Microsoft.Extensions.Logging;
using Zip.InstallmentsService.Test.TestHelpers;

namespace Zip.InstallmentsService.Test
{
    public class PaymentPlanControllerTests
    {
        private Mock<IPaymentService> _paymentServiceMock;
        private Mock<ILogger<PaymentPlanController>> _logger;

        public PaymentPlanControllerTests()
        {
            _paymentServiceMock = new Mock<IPaymentService>();
            _logger= new Mock<ILogger<PaymentPlanController>>();
        }

        [Fact]
        public async Task Given_PaymentPlanController_And_PaymentService_When_Called_GetAllPaymentPlansAsync_Returns_PaymentPlans()
        {
            //Arrange
            _paymentServiceMock.Setup(t => t.GetAllPaymentPlansAsync()).ReturnsAsync(TestHelper.GetTestPaymentPlans());
            var paymentPlanController = new PaymentPlanController(_logger.Object, _paymentServiceMock.Object);
            
            //Act
            var paymentPlans = await paymentPlanController.GetPaymentPlans();

            //Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<PaymentPlanDto>>>(paymentPlans);
            Assert.IsType<OkObjectResult>(actionResult.Result);
        }

        [Fact]
        public async Task Given_PaymentPlanController_And_PaymentService_When_Called_GetAllPaymentPlansAsync_Returns_NoOfInputtedPaymentPlans()
        {
            //Arrange
            _paymentServiceMock.Setup(t => t.GetAllPaymentPlansAsync()).ReturnsAsync(TestHelper.GetTestPaymentPlans());
            var paymentPlanController = new PaymentPlanController(_logger.Object, _paymentServiceMock.Object);

            //Act
            var paymentPlans = await paymentPlanController.GetPaymentPlans();

            //Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<PaymentPlanDto>>>(paymentPlans);
            Assert.Equal(1,((IEnumerable<PaymentPlanDto>)((OkObjectResult)actionResult.Result).Value).Count());
        }

        [Fact]
        public async Task Given_PaymentPlanController_And_PaymentService_With_PaymentId_When_Called_GetPaymentPlanAsync_Returns_NoOfInputtedPaymentPlans()
        {
            //Arrange
            var paymentId = Guid.NewGuid();
            _paymentServiceMock.Setup(t => t.GetPaymentPlanAsync(paymentId)).ReturnsAsync(TestHelper.GetTestPaymentPlanById(paymentId));
            var paymentPlanController = new PaymentPlanController(_logger.Object, _paymentServiceMock.Object);

            //Act
            var paymentPlan = await paymentPlanController.GetPaymentPlan(paymentId);

            //Assert
            var actionResult = Assert.IsType<ActionResult<PaymentPlanDto>>(paymentPlan);
            Assert.NotNull(((ObjectResult)actionResult.Result).Value);
        }

        [Fact]
        public async Task Given_PaymentPlanController_And_PaymentService_With_Invalid_PaymentId_When_Called_GetPaymentPlanAsync_Returns_NotFoundResult()
        {
            //Arrange
            var paymentId = Guid.NewGuid();
            _paymentServiceMock.Setup(t => t.GetPaymentPlanAsync(paymentId)).ReturnsAsync((PaymentPlanDto)null);
            var paymentPlanController = new PaymentPlanController(_logger.Object, _paymentServiceMock.Object);

            //Act
            var paymentPlan = await paymentPlanController.GetPaymentPlan(paymentId);

            //Assert
            var actionResult = Assert.IsType<ActionResult<PaymentPlanDto>>(paymentPlan);
            //Assert.Null(actionResult.Result);
            Assert.IsType<NotFoundResult>(actionResult.Result);
        }

        [Fact]
        public void Given_PaymentPlanController_And_Null_PaymentService_When_Called_GetAllPaymentPlansAsync_Throws_ArgumentException()
        {
            //Arrange
            Assert.Throws<ArgumentNullException>(() => new PaymentPlanController(_logger.Object, null));
        }

        [Fact]
        public void Given_PaymentPlanController_And_Null_LoggerInstance_When_Called_GetAllPaymentPlansAsync_Throws_ArgumentException()
        {
            //Arrange
            _paymentServiceMock.Setup(t => t.GetAllPaymentPlansAsync()).ReturnsAsync(TestHelper.GetTestPaymentPlans());

            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => new PaymentPlanController(null, _paymentServiceMock.Object));
        }

        [Fact]
        public async Task Given_PaymentPlanController_And_PaymentService_And_Empty_Plan_Result_When_Called_GetAllPaymentPlansAsync_Returns_OKResult()
        {
            //Arrange
            _paymentServiceMock.Setup(t => t.GetAllPaymentPlansAsync()).ReturnsAsync(new List<PaymentPlanDto>());
            var paymentPlanController = new PaymentPlanController(_logger.Object, _paymentServiceMock.Object);

            //Act
            var paymentPlans = await paymentPlanController.GetPaymentPlans();

            //Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<PaymentPlanDto>>>(paymentPlans);
            Assert.IsType<OkObjectResult>(actionResult.Result);
        }

        [Fact]
        public async Task Given_PaymentPlanController_And_PaymentService_And_Empty_Plan_Result_When_Called_GetAllPaymentPlansAsync_Returns_IsAssignablesToDtos()
        {
            //Arrange
            _paymentServiceMock.Setup(t => t.GetAllPaymentPlansAsync()).ReturnsAsync(new List<PaymentPlanDto>());
            var paymentPlanController = new PaymentPlanController(_logger.Object, _paymentServiceMock.Object);

            //Act
            var paymentPlans = await paymentPlanController.GetPaymentPlans();

            //Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<PaymentPlanDto>>>(paymentPlans);
            Assert.IsAssignableFrom<IEnumerable<PaymentPlanDto>>(((OkObjectResult)actionResult.Result).Value);
        }


        [Fact]
        public async Task Given_PaymentPlanController_And_PaymentService_And_Null_Results_When_Called_GetAllPaymentPlansAsync_Returns_OKResult()
        {
            //Arrange
            _paymentServiceMock.Setup(t => t.GetAllPaymentPlansAsync()).ReturnsAsync((List<PaymentPlanDto>)null);
            var paymentPlanController = new PaymentPlanController(_logger.Object, _paymentServiceMock.Object);

            //Act
            var paymentPlans = await paymentPlanController.GetPaymentPlans();

            //Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<PaymentPlanDto>>>(paymentPlans);
            Assert.IsType<OkObjectResult>(actionResult.Result);
        }

        [Fact]
        public async Task Given_PaymentPlanController_And_PaymentService_When_Called_CreatePaymentPlanAsync_With_Invalid_Amount_Return_BadRequestResult()
        {
            var paymentId = Guid.NewGuid();

            //Arrange
            _paymentServiceMock.Setup(t => t.CreatePaymentPlan(0M,4,6)).ReturnsAsync(TestHelper.GetTestPaymentPlanById(paymentId));
            var paymentPlanController = new PaymentPlanController(_logger.Object, _paymentServiceMock.Object);

            //Act
            var paymentPlan = await paymentPlanController.CreatePaymentPlan(0M, 4, 6);

            //Assert
            var actionResult = Assert.IsType<ActionResult<PaymentPlanDto>>(paymentPlan);
            Assert.IsType<BadRequestResult>(actionResult.Result);
        }

        [Fact]
        public async Task Given_PaymentPlanController_And_PaymentService_When_Called_CreatePaymentPlanAsync_With_Invalid_Installments_Return_BadRequestResult()
        {
            var paymentId = Guid.NewGuid();

            //Arrange
            _paymentServiceMock.Setup(t => t.CreatePaymentPlan(10M, 0, 6)).ReturnsAsync(TestHelper.GetTestPaymentPlanById(paymentId));
            var paymentPlanController = new PaymentPlanController(_logger.Object, _paymentServiceMock.Object);

            //Act
            var paymentPlan = await paymentPlanController.CreatePaymentPlan(10M, 0, 6);

            //Assert
            var actionResult = Assert.IsType<ActionResult<PaymentPlanDto>>(paymentPlan);
            Assert.IsType<BadRequestResult>(actionResult.Result);
        }

        [Fact]
        public async Task Given_PaymentPlanController_And_PaymentService_When_Called_CreatePaymentPlanAsync_With_Invalid_Frequency_Return_BadRequestResult()
        {
            var paymentId = Guid.NewGuid();

            //Arrange
            _paymentServiceMock.Setup(t => t.CreatePaymentPlan(10M, 10, 0)).ReturnsAsync(TestHelper.GetTestPaymentPlanById(paymentId));
            var paymentPlanController = new PaymentPlanController(_logger.Object, _paymentServiceMock.Object);

            //Act
            var paymentPlan = await paymentPlanController.CreatePaymentPlan(10M, 10, 0);

            //Assert
            var actionResult = Assert.IsType<ActionResult<PaymentPlanDto>>(paymentPlan);
            Assert.IsType<BadRequestResult>(actionResult.Result);
        }

        [Fact]
        public async Task Given_PaymentPlanController_And_PaymentService_When_Called_CreatePaymentPlanAsync_Return_BadNoContentResult()
        {
            //Arrange
            _paymentServiceMock.Setup(t => t.CreatePaymentPlan(10M, 5, 6)).ReturnsAsync((PaymentPlanDto)null);
            var paymentPlanController = new PaymentPlanController(_logger.Object, _paymentServiceMock.Object);

            //Act
            var paymentPlan = await paymentPlanController.CreatePaymentPlan(100M, 2, 4);

            //Assert
            var actionResult = Assert.IsType<ActionResult<PaymentPlanDto>>(paymentPlan);
            Assert.IsType<NoContentResult>(actionResult.Result);
        }

        [Fact]
        public async Task Given_PaymentPlanController_And_PaymentService_When_Called_CreatePaymentPlanAsync_Return_ContentCreatedResult()
        {
            var paymentId = Guid.NewGuid();

            //Arrange
            _paymentServiceMock.Setup(t => t.CreatePaymentPlan(100M, 2, 4)).ReturnsAsync(TestHelper.GetTestPaymentPlanById(paymentId));
            var paymentPlanController = new PaymentPlanController(_logger.Object, _paymentServiceMock.Object);

            //Act
            var paymentPlan = await paymentPlanController.CreatePaymentPlan(100M, 2, 4);

            //Assert
            var actionResult = Assert.IsType<ActionResult<PaymentPlanDto>>(paymentPlan);
            Assert.IsType<CreatedAtRouteResult>(actionResult.Result);
        }
    }
}
