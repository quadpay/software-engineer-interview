using AutoMapper;
using System;
using System.Linq;
using Zip.InstallmentsService.Data.Interface;
using Zip.InstallmentsService.Entity.Dto;
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

        /// <summary>
        /// Intialization in Constructor
        /// </summary>
        /// <param name="paymentPlanRepository"></param>
        /// <param name="installmentProvider"></param>
        /// <param name="mapper"></param>
        public PaymentPlanProvider(IPaymentPlanRepository paymentPlanRepository, IInstallmentProvider installmentProvider, IMapper mapper)
        {
            _paymentPlanRepository = paymentPlanRepository;
            _installmentProvider = installmentProvider;
            _mapper = mapper;
        }
        
        /// <summary>
        /// Get Payment plan by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PaymentPlanDto GetById(Guid id)
        {
            var response = _paymentPlanRepository.GetById(id);
            return Mapper.Map<PaymentPlanDto>(response);
        }

        /// <summary>
        /// Logic to create payment plan
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public PaymentPlanDto Create(PaymentPlanDto requestModel)
        {
            if (requestModel == null) return null;

            //Calculate installments
            requestModel.Installments = _installmentProvider.CalculateInstallments(requestModel)?.ToList();

            //Create Payment plan
            var response = _paymentPlanRepository.Create(requestModel);

            return Mapper.Map<PaymentPlanDto>(response);
        }


        /// <summary>
        /// Validate Payment plan create request
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public ValidateRequestDto ValidateCreateRequest(PaymentPlanDto requestModel)
        {
            var responemodel = new ValidateRequestDto();
            if(requestModel == null) responemodel.Message = "Bad Request.";
            else if (requestModel.NoOfInstallments == 0) responemodel.Message = "Please select no of installments.";
            else if (requestModel.FrequencyInDays == 0) responemodel.Message = "Please select frequency.";
            
            responemodel.IsValid = true;
            return responemodel;
        }

    }
}
