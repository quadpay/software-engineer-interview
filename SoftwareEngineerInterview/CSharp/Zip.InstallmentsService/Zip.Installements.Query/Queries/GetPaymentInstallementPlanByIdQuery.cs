namespace Zip.Installements.Query.Queries
{
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Zip.Installements.Contract.Response;
    using Zip.Installements.Infrastructure.Context;

    public class GetPaymentInstallementPlanByIdQuery : IRequest<List<InstallementDetailsResponse>>
    {
        public int Id { get; set; }

        public class GetPaymentInstallementPlanByIdQueryHandler : IRequestHandler<GetPaymentInstallementPlanByIdQuery, List<InstallementDetailsResponse>>
        {
            private readonly ZipPayContext zipPayContext;

            public GetPaymentInstallementPlanByIdQueryHandler(ZipPayContext zipPayContext)
            {
                this.zipPayContext = zipPayContext;
            }
            public async Task<List<InstallementDetailsResponse>> Handle(GetPaymentInstallementPlanByIdQuery request, CancellationToken cancellationToken)
            {
                return await this.zipPayContext.InstallementPlan
                           .AsNoTracking()
                           .Where(x => x.PaymentId == request.Id)
                           .Select(installementPlan => new InstallementDetailsResponse()
                           {
                               PaymentId = installementPlan.PaymentId,
                               DueDate = installementPlan.DueDate.ToString("MM/dd/yyyy"),
                               DueAmount = installementPlan.DueAmount
                           }).ToListAsync();
            }
        }
    }
}
