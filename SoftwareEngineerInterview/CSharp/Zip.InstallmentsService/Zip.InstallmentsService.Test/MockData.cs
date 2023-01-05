using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Zip.InstallmentsService.Model;

namespace Zip.InstallmentsService.Test
{
    /// <summary>
    /// This class consists of mock data which is useful for execute mock tests
    /// </summary>
    public class MockData
    {
        /// <summary>
        /// This method generate calculated payment plan mocked data
        /// </summary>
        /// <returns>payment plan</returns>
        internal PaymentPlan GetPaymentPlan()
        {
            PaymentPlan paymentPlan = new PaymentPlan();
            paymentPlan.Id = GetGuid();
            paymentPlan.PurchaseAmount = 100;
            paymentPlan.Installments = new List<Installment>();
            List<Installment> installment = new List<Installment>
            {
                new Installment { Amount = 25, DueDate = Convert.ToDateTime("2022-12-31"),Id=new Guid("B193779C-ED80-4D69-AD21-5816F07AE1E4")},
                new Installment { Amount = 25, DueDate = Convert.ToDateTime("2023-01-14"),Id=new Guid("4ECDED25-7992-48D1-95BE-3C649069743D")},
                new Installment { Amount = 25, DueDate = Convert.ToDateTime("2023-01-28"),Id=new Guid("A1477112-D821-434F-8DB4-0279C180D245")},
                new Installment { Amount = 25, DueDate = Convert.ToDateTime("2023-02-11"),Id=new Guid("BD177FE5-7869-4275-B873-9A3563E46C4A")}
            };
            paymentPlan.Installments = installment;

            return paymentPlan;
        }
        /// <summary>
        /// This method generate empty payment plan
        /// </summary>
        /// <returns>empty payment plan</returns>
        internal PaymentPlan GetEmptyPaymentPlan()
        {
            PaymentPlan paymentPlan = new PaymentPlan();
            return paymentPlan;
        }

        /// <summary>
        /// This method generate request object for creating payment plan
        /// </summary>
        /// <returns>input request</returns>
        internal InstallmentRequest GetInstallmentRequest()
        {
            InstallmentRequest installmentRequest = new InstallmentRequest
            { FrequencyOfInstallment = 14, Installments = 4, OrderAmount = 100, StartDate = DateTime.Now };

            return installmentRequest;
        }
        internal InstallmentRequest GetInstallmentRequestFail()
        {
            InstallmentRequest installmentRequest = new InstallmentRequest();

            return installmentRequest;
        }

        /// <summary>
        /// This method generate mocked response object for installment details.
        /// </summary>
        /// <returns>mocked response object</returns>
        internal InstallmentResponse GetInstallmentResponse()
        {
            InstallmentResponse installmentResponse = new InstallmentResponse
            {
                ResponseMessage = "Installment Calculated and stored successfully.",
                PaymentPlan = GetPaymentPlan()
            };
        return installmentResponse;
    }
        /// <summary>
        /// This method generate mocked Guid to be used to fetch payment plan
        /// </summary>
        /// <returns>Guid</returns>
        internal Guid GetGuid()
        {
            return new Guid("BBA85D17-3F6B-4839-B0C0-F1E3FAE7B454");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal Guid GetRandomGuid()
        {
            return Guid.NewGuid();
        }

        internal async Task<HttpContext> GetKeynotFoundHttpContext()
        {
            HttpContext context = new DefaultHttpContext();
            ErrorResponse errorResponse = new ErrorResponse
            {
                Success = false, StatusCode = (int)HttpStatusCode.NotFound 
            };
            var result = JsonSerializer.Serialize(errorResponse);
           await context.Response.WriteAsync(result);
            return context;
        }
    }
}
