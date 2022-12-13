namespace Zip.InstallmentsService.Core.PaymentPlanAggregate.Queries
{
    /// <summary>
    /// Mediator query for fetching payment plan by Id
    /// </summary>
    /// <param name="Id">Payment plan Id</param>
    public record GetPaymentPlanByIdQuery(Guid Id) : IRequest<PaymentPlanResponse>;
}