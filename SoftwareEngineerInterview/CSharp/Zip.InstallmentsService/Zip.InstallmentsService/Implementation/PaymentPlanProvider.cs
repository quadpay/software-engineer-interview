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
        public PaymentPlanDto Create(CreatePaymentPlanDto requestModel)
        {
            //Validate request
            var validateRequest = this.ValidateCreateRequest(requestModel);
            if (!validateRequest.IsValid) return null;

            //convert via AutoMapper
            var paymentPlanDto = Mapper.Map<PaymentPlanDto>(requestModel);

            //Calculate installments
            paymentPlanDto.Installments = _installmentProvider.CalculateInstallments(paymentPlanDto)?.ToList();

            //Create Payment plan
            var response = _paymentPlanRepository.Create(paymentPlanDto);

            return Mapper.Map<PaymentPlanDto>(response);
        }


        /// <summary>
        /// Validate Payment plan create request
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public ValidateRequestDto ValidateCreateRequest(CreatePaymentPlanDto requestModel)
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
