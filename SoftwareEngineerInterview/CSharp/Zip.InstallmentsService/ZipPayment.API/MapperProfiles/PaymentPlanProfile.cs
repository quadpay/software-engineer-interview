using AutoMapper;
using Zip.InstallmentsService.DomainObjects;
using ZipPayment.API.Models;

namespace ZipPayment.API.MapperProfiles
{
    /// <summary>
    /// A Class to Map to and from PaymentPlan domain objects in PaymentPlan entity objects
    /// </summary>
    public class PaymentPlanProfile : Profile
    {
        /// <summary>
        /// Constructor: Map to and from PaymentPlan domain objects in PaymentPlan entity objects
        /// </summary>
        public PaymentPlanProfile()
        {
            //CreateMap<DataAccess.Entities.PaymentPlanEntity, PaymentPlan>();
            CreateMap<DataAccess.Entities.PaymentPlanEntity, PaymentPlanDto>();
        }
    }
}
