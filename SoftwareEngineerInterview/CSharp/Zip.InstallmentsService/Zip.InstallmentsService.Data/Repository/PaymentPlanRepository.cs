using System;
using System.Collections.Generic;
using System.Text;
using Zip.InstallmentsService.Data.Interface;
using Zip.InstallmentsService.Data.Models;
using Zip.InstallmentsService.Entity.Request;
using Zip.InstallmentsService.Entity.Response;

namespace Zip.InstallmentsService.Data.Repository
{
    public class PaymentPlanRepository : IPaymentPlanRepository
    {
        public PaymentPlanResponseModel Create(CreatePaymentPlanRequestModel requestModel)
        {
            var result = new PaymentPlanDbViewModel();



            throw new NotImplementedException();
        }

        public PaymentPlanResponseModel Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
