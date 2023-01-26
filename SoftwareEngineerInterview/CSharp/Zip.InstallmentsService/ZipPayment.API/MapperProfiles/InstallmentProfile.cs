using AutoMapper;
using Zip.InstallmentsService.DomainObjects;
using ZipPayment.API.Models;

namespace ZipPayment.API.MapperProfiles
{
    /// <summary>
    /// A class to map  to and from Installment domain objects in Installment entity objects
    /// </summary>
    public class InstallmentProfile : Profile
    {
        /// <summary>
        /// Constructor: map  to and from Installment domain objects in Installment entity objects
        /// </summary>
        public InstallmentProfile()
        {
            CreateMap<Installment, DataAccess.Entities.InstallmentEntity>();
            CreateMap<DataAccess.Entities.InstallmentEntity, InstallmentDto>();
        }
    }
}
