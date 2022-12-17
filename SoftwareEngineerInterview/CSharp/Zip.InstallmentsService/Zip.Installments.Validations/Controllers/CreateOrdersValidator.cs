using FluentValidation;
using Zip.InstallmentsService.Models;

namespace Zip.Installments.Validations.Controllers
{
    public class CreateOrdersValidator: AbstractValidator<Order>
    {
        public CreateOrdersValidator()
        {
            RuleFor(model => model.Email).NotEmpty().EmailAddress();
        }
    }
}
