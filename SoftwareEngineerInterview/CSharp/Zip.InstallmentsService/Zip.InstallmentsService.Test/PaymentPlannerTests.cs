using Shouldly;
using Xunit;
using Zip.InstallmentsService.Services;

namespace Zip.InstallmentsService.Test
{
    public class PaymentPlannerTests
    {
        [Fact]
        public void Given_PaymentPlanWithInValidOrderAmount_When_CreateInstanceOfPaymentPlanner_Then_ThrowsArgumentException()
        {
            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => new PaymentPlanner(0M));
            Assert.Throws<ArgumentException>(() => new PaymentPlanner(0.5M));
            Assert.Throws<ArgumentException>(() => new PaymentPlanner(-10M));
        }

        [Fact]
        public void Given_PaymentPlanWithValidOrderAmountAndNoOfInstallmentsAndFrequency_When_GetPaymentCalled_Then_CreatePaymentPlan()
        {
            //Arrange
            var paymentPlanner = new PaymentPlanner(100M);

            //Act
            var paymentPlan = paymentPlanner.GetPaymentPlan(4, 4);

            //Assert
            Assert.All(paymentPlan, t => Assert.True(t.Amount == 25M));
        }

        [Fact]
        public void Given_PaymentPlanWithValidOrderAmountAndInvalidNoOfInstallmentsAndFrequency_When_GetPaymentCalled_Then_ThrowsArgumentException()
        {
            //Arrange
            var paymentPlanner = new PaymentPlanner(100M);

            //Act
            //Assert
            Assert.Throws<ArgumentException>(() => paymentPlanner.GetPaymentPlan(0, 0).ToArray());
            Assert.Throws<ArgumentException>(() =>  paymentPlanner.GetPaymentPlan(-1, -1).ToArray());
        }

        [Fact]
        public void Given_PaymentPlanWithValidOrderAmountAndOneInstallmentsAndOneFrequency_When_GetPaymentCalled_Then_CreatePaymentPlan()
        {
            //Arrange
            var paymentPlanner = new PaymentPlanner(100M);

            //Act
            var paymentPlan = paymentPlanner.GetPaymentPlan(1, 1).ToArray();

            //Assert
            Assert.All(paymentPlan, t => Assert.True(t.Amount == 100M));
            Assert.All(paymentPlan, t => Assert.True(t.DueDate.Date == DateTime.Now.Date));
        }

        [Fact]
        public void Given_PaymentPlanWithValidMinimalOrderAmountAnd100InstallmentsAndFourFrequency_When_GetPaymentCalled_Then_CreatePaymentPlan()
        {
            //Arrange
            var paymentPlanner = new PaymentPlanner(1M);

            //Act
            var paymentPlan = paymentPlanner.GetPaymentPlan(100, 4).ToArray();

            //Assert
            Assert.All(paymentPlan, t => Assert.True(t.Amount == 0.01M));
        }
    }
}
