using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zip.InstallmentsService.Data.Interface;
using Zip.InstallmentsService.Data.Models;
using Zip.InstallmentsService.Entity.Dto;
using Zip.InstallmentsService.Helper;
using Zip.InstallmentsService.Interface;

namespace Zip.InstallmentsService.Implementation
{
    /// <summary>
    /// Core class which defines all bussiness logic for a payment plan.
    /// </summary>
    public class PaymentPlanProvider : IPaymentPlanProvider
    {
        private readonly IPaymentPlanRepository _paymentPlanRepository;
        private readonly IInstallmentProvider _installmentProvider;
        private IMapper _mapper { get; }

        public PaymentPlanProvider(IPaymentPlanRepository paymentPlanRepository, IInstallmentProvider installmentProvider, IMapper mapper)
        {
            _paymentPlanRepository = paymentPlanRepository;
            _installmentProvider = installmentProvider;
            _mapper = mapper;
        }

        public PaymentPlanDto Create(PaymentPlanDto requestModel)
        {
            if (requestModel == null) return null;

            requestModel.Installments = _installmentProvider.CalculateInstallments(requestModel)?.ToList();
            var response = _paymentPlanRepository.Create(requestModel);

            return Mapper.Map<PaymentPlanDto>(response);
        }

        public PaymentPlanDto Get(int id)
        {
            var response = _paymentPlanRepository.Get(id);
            return Mapper.Map<PaymentPlanDto>(response);
        }

        public ValidateRequestDto ValidateCreateRequest(PaymentPlanDto requestModel)
        {
            var responemodel = new ValidateRequestDto();
            if(requestModel == null) responemodel.Message = "Bad Request.";
            else if (requestModel.NoOfInstallments == 0) responemodel.Message = "Please select no of installments.";
            else if (requestModel.FrequencyInDays == 0) responemodel.Message = "Please select frequency.";
            else if (requestModel.FrequencyType == 0) responemodel.Message = "Please select frequency type.";
            return responemodel;
        }

    }
}
