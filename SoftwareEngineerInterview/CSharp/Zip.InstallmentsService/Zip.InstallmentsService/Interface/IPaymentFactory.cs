
namespace Zip.InstallmentsService.Interface
{
    /// <summary>
    /// Factory interface for creating payment planner object
    /// </summary>
    public interface IPaymentFactory
    {
        /// <summary>
        /// Builds the PaymentPlan instance.
        /// </summary>
        /// <param name="purchaseAmount">The total amount for the purchase that the customer is making.</param>
        /// <returns>The PaymentPlan created with all properties set.</returns>
        IPaymentPlanner CreatePaymentPlan(decimal purchaseAmount);
    }
}
