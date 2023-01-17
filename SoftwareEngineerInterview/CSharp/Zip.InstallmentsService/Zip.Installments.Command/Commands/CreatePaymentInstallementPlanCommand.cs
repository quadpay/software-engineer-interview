namespace Zip.Installments.Command.Commands
{
    using MediatR;
    using System.Threading.Tasks;
    using Zip.Installments.Domain.Entities;
    using Zip.Installments.Infrastructure.Context;

    /// <summary>
    /// Class defines method to create payment installement plan.
    /// </summary>
    public class CreatePaymentInstallementPlanCommand : IRequest<int>
    {
        private readonly Payment payment;

        public CreatePaymentInstallementPlanCommand(Payment payment)
        {
            this.payment = payment;
        }

        public class CreatePaymentInstallementPlanCommandHandler : IRequestHandler<CreatePaymentInstallementPlanCommand, int>
        {
            private readonly ZipPayContext zipPayContext;

            public CreatePaymentInstallementPlanCommandHandler(ZipPayContext zipPayContext)
            {
                this.zipPayContext = zipPayContext;
            }

            public async Task<int> Handle(CreatePaymentInstallementPlanCommand request, CancellationToken cancellationToken)
            {
                this.zipPayContext.Payment.Add(request.payment);

                await this.zipPayContext.SaveChangesAsync();

                return request.payment.Id;
            }
        }
    }
}
