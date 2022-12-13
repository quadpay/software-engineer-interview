namespace Zip.InstallmentsService.Core.PaymentPlanAggregate.Validation
{
    /// <summary>
    /// Used to validate create payment plan request
    /// </summary>
    public class CreatePaymentPlanRequestValidator : AbstractValidator<CreatePaymentPlanRequest>
    {
        #region Constructor

        /// <summary>
        /// Creates object of <see cref="CreatePaymentPlanRequestValidator"/>
        /// </summary>
        public CreatePaymentPlanRequestValidator()
        {
            RuleFor(model => model.PurchaseAmount).GreaterThanOrEqualTo(1M).WithMessage($"Min value for purchase amount is $1.");
            RuleFor(model => model.NumberOfInstallments).GreaterThanOrEqualTo(1).WithMessage("Min value for number of installments is 1.");
            RuleFor(model => model.Frequency).NotNull().GreaterThanOrEqualTo(1).WithMessage("Min value for frequency is 1.");
            RuleFor(model => model.PurhcaseDate).Must(date => date != default(DateTime)).WithMessage($"Purhcase date shold not be null or default.");
        }

        #endregion
    }
}
