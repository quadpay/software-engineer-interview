using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Zip.InstallmentsService.Data.Models;
using Zip.InstallmentsService.Entity.Dto;

namespace Zip.InstallmentsService.Entity
{
    public class PaymentPlanProfile : Profile
    {
        public PaymentPlanProfile()
        {
            CreateMap<PaymentPlanDto, PaymentPlan>();
            CreateMap<InstallmentDto, Installment>();
        }

    }
}
