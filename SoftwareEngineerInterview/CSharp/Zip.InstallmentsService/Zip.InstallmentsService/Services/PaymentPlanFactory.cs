using System;
using Zip.InstallmentsService.Interface;

namespace Zip.InstallmentsService.Services
{
    /// <summary>
    /// This class is responsible for building the PaymentPlan according to the Zip product definition.
    /// This class returns PaymentPlanner to create a installments
    /// </summary>
    public class PaymentPlanFactory : IPaymentFactory
    {
        /// <summary>
        /// Builds the PaymentPlan instance.
        /// </summary>
        /// <param name="purchaseAmount">The total amount for the purchase that the customer is making.</param>
        /// <returns>The PaymentPlan created with all properties set.</returns>
        public IPaymentPlanner CreatePaymentPlan(decimal purchaseAmount)
        {
            if (purchaseAmount < 1)
                throw new ArgumentException($"Minimum purchase amount must be multiple of 1. ", nameof(purchaseAmount));

            // Create a PaymentPlanner object
            return new PaymentPlanner(purchaseAmount);
        }
    }
}
