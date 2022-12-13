namespace Zip.InstallmentsService.Test
{
    public class PaymentPlanTests
    {
        #region Constructor

        /// <summary>
        /// Creates instance of <see cref="PaymentPlanTests"/>
        /// </summary>
        public PaymentPlanTests() : base()
        {
        }

        #endregion

        #region Tests

        /// <summary>
        /// Test used to validate succussful scenario's of <see cref="PaymentPlan"/>
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
        public void CreatePaymentPlan_Successful(decimal purchaseAmount,
                                                 int numberOfInstallments,
                                                 int frequency,
                                                 decimal installmentAmount)
        {
            var plan = new PaymentPlan(purchaseAmount);

            plan.CreatePaymentPlan(DateTime.Now, numberOfInstallments, frequency);
            
            Assert.NotNull(plan);
            Assert.True(plan.PurchaseAmount == purchaseAmount);
            Assert.True(plan.Installments.Count == numberOfInstallments);

            plan.Installments.ForEach(installment =>
            {
                Assert.True(installment.Amount == installmentAmount);
            });
        }

        /// <summary>
        /// Test used to validate unsuccussful scenario's of <see cref="PaymentPlan"/>
        /// </summary>
        /// <param name="purchaseAmount">The purchase amount</param>
        /// <param name="numberOfInstallments">Number of installments</param>
        /// <param name="frequency">Frequency</param>
        [Theory]
        [InlineData(0, 4, 14)]
        [InlineData(25, 0, 14)]
        [InlineData(82, 3, 0)]
        public void CreatePaymentPlan_UnSuccessful(decimal purchaseAmount,
                                                   int numberOfInstallments,
                                                   int frequency)
        {
            var plan = new PaymentPlan(purchaseAmount);

            plan.CreatePaymentPlan(DateTime.Now, numberOfInstallments, frequency);

            Assert.NotNull(plan);
            Assert.True(plan.Installments.Count == 0);
        }

        #endregion
    }
}
