using AutoMapper;
using Zip.InstallmentsService.Data.Models;
using Zip.InstallmentsService.Entity.Dto;

namespace Zip.InstallmentsService.Entity
{
    /// <summary>
    /// Created profiles for AutoMapper of entities
    /// </summary>
    public class PaymentPlanProfile : Profile
    {
        public PaymentPlanProfile()
        {
            
            CreateMap<CreatePaymentPlanDto, PaymentPlanDto>();
            CreateMap<PaymentPlan, PaymentPlanDto>();
            CreateMap<Installment, InstallmentDto>();
        }

    }
}
