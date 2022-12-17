using FluentValidation;
using Zip.Installments.ViewModel.Orders;

namespace Zip.Installments.Validations.Controllers
{
    public class CreateOrdersValidator: AbstractValidator<OrdersViewModel>
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
        }
    }
}
