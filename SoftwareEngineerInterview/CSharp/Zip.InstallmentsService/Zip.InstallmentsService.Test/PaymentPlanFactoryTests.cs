using Shouldly;
using Xunit;
using Zip.InstallmentsService.Services;

namespace Zip.InstallmentsService.Test
{
    public class PaymentPlanFactoryTests
    {
        [Fact]
        public void WhenCreatePaymentPlanWithValidOrderAmount_ShouldReturnValidPaymentPlan()
        {
            // Arrange
            var paymentPlanFactory = new PaymentPlanFactory();
            
            // Act
            var paymentPlan = paymentPlanFactory.CreatePaymentPlan(123.45M);

            // Assert
            paymentPlan.ShouldNotBeNull();
        }

        [Fact]
        public void WhenCreatePaymentPlanWithValidMinimumOrderAmount_ShouldReturnValidPaymentPlan()
        {
            // Arrange
            var paymentPlanFactory = new PaymentPlanFactory();

            // Act
            var paymentPlan = paymentPlanFactory.CreatePaymentPlan(1M);

            // Assert
            paymentPlan.ShouldNotBeNull();
        }

        [Fact]
        public void WhenCreatePaymentPlanWithInvalidOrderAmount_ShouldThrowArgumentException()
        {
            // Arrange
            var paymentPlanFactory = new PaymentPlanFactory();

            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => paymentPlanFactory.CreatePaymentPlan(0M));
            Assert.Throws<ArgumentException>(() => paymentPlanFactory.CreatePaymentPlan(0.5M));
            Assert.Throws<ArgumentException>(() => paymentPlanFactory.CreatePaymentPlan(-10M));
        }
    }
}
