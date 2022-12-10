using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zip.InstallmentsService.Data.Interface;
using Zip.InstallmentsService.Entity.Request;
using Zip.InstallmentsService.Entity.Response;
using Zip.InstallmentsService.Interface;

namespace Zip.InstallmentsService.Implementation
{
    /// <summary>
    /// Core class which defines all bussiness logic for a payment plan.
    /// </summary>
    public class PaymentPlanProvider : IPaymentPlanProvider
    {
        private readonly IPaymentPlanRepository _paymentPlanRepository;

        public PaymentPlanProvider(IPaymentPlanRepository paymentPlanRepository)
        {
            _paymentPlanRepository = paymentPlanRepository;
        }

        public PaymentPlanResponseModel Create(CreatePaymentPlanRequestModel requestModel)
        {
            return _paymentPlanRepository.Create(requestModel);
        }

        public PaymentPlanResponseModel Get(int id)
        {
            return _paymentPlanRepository.Get(id);
        }

        public ValidateResponseModel ValidatePaymentPlanCreateRequest(CreatePaymentPlanRequestModel requestModel)
        {
            var responemodel = new ValidateResponseModel();
            if (requestModel.NoOfInstallments == 0) responemodel.Message = "Please select no of installments.";
            else if (requestModel.Frequency == 0) responemodel.Message = "Please select frequency.";
            else if (requestModel.FrequencyType == 0) responemodel.Message = "Please select frequency type.";
            return responemodel;
        }



        private void CalculatePaymentPlan(CreatePaymentPlanRequestModel requestModel)
        { 
        
        
        }


    }
}
