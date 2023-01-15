namespace Zip.Installements.Command.Commands
{
    using MediatR;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Zip.Installements.Contract.Request;
    using Zip.Installements.Domain.Entities;
    using Zip.Installements.Infrastructure.Context;

    public class CreatePaymentInstallementPlanCommand : IRequest<int>
    {
        public Payment payment { get; set; }

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
