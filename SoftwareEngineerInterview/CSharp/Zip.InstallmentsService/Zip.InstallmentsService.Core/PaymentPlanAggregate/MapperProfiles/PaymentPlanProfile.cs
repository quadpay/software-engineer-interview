namespace Zip.InstallmentsService.Core.PaymentPlanAggregate.MapperProfiles
{
    /// <summary>
    /// Used to create auto mapper profile for <see cref="PaymentPlan"/> and <see cref="PaymentPlanResponse"/>
    /// </summary>
    public class PaymentPlanProfile : Profile
    {
        #region Constructor

        /// <summary>
        /// Creates instance of <see cref="PaymentPlanProfile"/>
        /// </summary>
        public PaymentPlanProfile()
        {
            CreateMap<PaymentPlan, PaymentPlanResponse>()
                .ForMember(dest => dest.PaymentPlanId, opt => opt.MapFrom(src => src.Id));

            CreateMap<Installment, InstallmentResponse>()
                .ForMember(dest => dest.InstallmentId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.DueDate.ToString("MMM dd, yyyy")));
        }

        #endregion
    }
}
