namespace Zip.InstallmentsService.Test
{
    public class CreatePaymentPlanRequestValidatorTests : PaymentPlanTestBase
    {
        #region Private Variables 

        private readonly CreatePaymentPlanRequestValidator _createPaymentPlanRequestValidator;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates instance of <see cref="CreatePaymentPlanRequestValidatorTests"/>
        /// </summary>
        public CreatePaymentPlanRequestValidatorTests() : base()
        {
            _createPaymentPlanRequestValidator = new CreatePaymentPlanRequestValidator();
        }

        #endregion

        #region Tests

        /// <summary>
        /// Test used to validate purchase amount min value
        /// </summary>
        /// <param name="purchaseAmount">The purchase amount</param>
        /// <param name="numberOfInstallments">Number of installments</param>
        /// <param name="frequency">Frequency</param>
        [Theory]
        [InlineData(0, 4, 14)]       
        public void ShouldShowErrorMinPurchaseAmount(decimal purchaseAmount,
                                                     int numberOfInstallments,
                                                     int frequency)
        {
            var request = GeneratePaymentPlanRequest(purchaseAmount, numberOfInstallments, frequency);

            var result = _createPaymentPlanRequestValidator.TestValidate(request);
            result.ShouldHaveValidationErrorFor(purchase => purchase.PurchaseAmount).WithErrorMessage("Min value for purchase amount is $1.");
        }

        /// <summary>
        /// Test used to validate min value for number of installment
        /// </summary>
        /// <param name="purchaseAmount">The purchase amount</param>
        /// <param name="numberOfInstallments">Number of installments</param>
        /// <param name="frequency">Frequency</param>
        [Theory]
        [InlineData(25, 0, 14)]
        public void ShouldShowErroMinNumberOfInstallment(decimal purchaseAmount,
                                                         int numberOfInstallments,
                                                         int frequency)
        {
            var request = GeneratePaymentPlanRequest(purchaseAmount, numberOfInstallments, frequency);

            var result = _createPaymentPlanRequestValidator.TestValidate(request);

            result.ShouldHaveValidationErrorFor(purchase => purchase.NumberOfInstallments).WithErrorMessage("Min value for number of installments is 1.");
        }

        /// <summary>
        /// Test used to validate min value for frequency
        /// </summary>
        /// <param name="purchaseAmount">The purchase amount</param>
        /// <param name="numberOfInstallments">Number of installments</param>
        /// <param name="frequency">Frequency</param>
        [Theory]
        [InlineData(82, 3, 0)]
        public void ShouldShowErroMinFrequecy(decimal purchaseAmount,
                                              int numberOfInstallments,
                                              int frequency)
        {
            var request = GeneratePaymentPlanRequest(purchaseAmount, numberOfInstallments, frequency);

            var result = _createPaymentPlanRequestValidator.TestValidate(request);

            result.ShouldHaveValidationErrorFor(purchase => purchase.Frequency).WithErrorMessage("Min value for frequency is 1.");
        }

        /// <summary>
        /// Test used for successful validation of all the feilds
        /// </summary>
        /// <param name="purchaseAmount">The purchase amount</param>
        /// <param name="numberOfInstallments">Number of installments</param>
        /// <param name="frequency">Frequency</param>
        [Theory]
        [InlineData(82, 3, 14)]
        public void ShouldNotShowAnyError(decimal purchaseAmount,
                                          int numberOfInstallments,
                                          int frequency)
        {
            var request = GeneratePaymentPlanRequest(purchaseAmount, numberOfInstallments, frequency);

            var result = _createPaymentPlanRequestValidator.TestValidate(request);

            result.ShouldNotHaveValidationErrorFor(purchase => purchase.PurchaseAmount);
        }

        #endregion
    }
}
