namespace Zip.Installments.Query.Queries
{
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Zip.Installments.Contract.Response;
    using Zip.Installments.Infrastructure.Context;

    /// <summary>
    /// Class defines method to get the payment installment plan based on the payment id passed.
    /// </summary>
    public class GetPaymentInstallmentPlanByIdQuery : IRequest<List<InstallmentDetailsResponse>>
    {
        private readonly int id;

        public GetPaymentInstallmentPlanByIdQuery(int id)
        {
            this.id = id;
        }

        public class GetPaymentInstallementPlanByIdQueryHandler : IRequestHandler<GetPaymentInstallmentPlanByIdQuery, List<InstallmentDetailsResponse>>
        {
            private readonly ZipPayContext zipPayContext;

            public GetPaymentInstallementPlanByIdQueryHandler(ZipPayContext zipPayContext)
            {
                this.zipPayContext = zipPayContext;
            }
            public async Task<List<InstallmentDetailsResponse>> Handle(GetPaymentInstallmentPlanByIdQuery request, CancellationToken cancellationToken)
            {
                return await this.zipPayContext.InstallementPlan
                           .AsNoTracking()
                           .Where(x => x.PaymentId == request.id)
                           .Select(installementPlan => new InstallmentDetailsResponse()
                           {
                               PaymentId = installementPlan.PaymentId,
                               DueDate = installementPlan.DueDate.ToString("MM/dd/yyyy"),
                               DueAmount = installementPlan.DueAmount
                           }).ToListAsync();
            }
        }
    }
}
