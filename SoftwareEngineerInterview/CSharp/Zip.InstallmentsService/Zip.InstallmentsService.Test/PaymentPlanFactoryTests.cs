using Shouldly;
using Xunit;

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
    }
}
