using FluentValidation;
using Zip.Installments.ViewModel.Orders;

namespace Zip.Installments.Validations.Controllers
{
    public class CreateOrdersValidator : AbstractValidator<OrdersViewModel>
    {
        public CreateOrdersValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(model => model.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.FirstName)
                .NotNull()
                .NotEmpty()
                .MinimumLength(1);

            RuleFor(x => x.LastName)
                .NotNull()
                .NotEmpty()
                .MinimumLength(1);

            RuleFor(x => x.NumberOfInstallments)
                .GreaterThan(1)
                .WithMessage("Should be more than one");

            RuleFor(x => x.PurchaseAmount)
                .GreaterThan(1)
                .WithMessage("Invalid amount");

            RuleFor(x => x.FirstPaymentDate)
                .GreaterThan(DateTime.Now.Date)
                .WithMessage("Invalid payment date");

            RuleFor(x => x.Frequency)
                .GreaterThan(1)
                .WithMessage("Payment frequency should more than one day");


        }
    }
}
