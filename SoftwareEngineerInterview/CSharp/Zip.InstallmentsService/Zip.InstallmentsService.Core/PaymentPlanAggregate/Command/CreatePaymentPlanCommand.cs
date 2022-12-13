namespace Zip.InstallmentsService.Core.PaymentPlanAggregate.Command
{
    /// <summary>
    /// Command used to create payment plan.
    /// </summary>
    /// <param name="PlanRequest">Create payment plan request of type <see cref="CreatePaymentPlanRequest"/></param>
    public record CreatePaymentPlanCommand(CreatePaymentPlanRequest PlanRequest) : IRequest<PaymentPlanResponse>;
}