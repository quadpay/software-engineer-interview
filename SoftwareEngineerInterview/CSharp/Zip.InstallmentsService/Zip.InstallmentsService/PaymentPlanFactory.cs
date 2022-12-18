using System;
using System.Collections.Generic;

namespace Zip.InstallmentsService
{
    /// <summary>
    /// This class is responsible for building the PaymentPlan according to the Zip product definition.
    /// </summary>
    public class PaymentPlanFactory:IPaymentPlanFactory
    {
        /// <summary>
        /// Builds the PaymentPlan instance.
        /// </summary>
        /// <param name="installmentRequest">The total amount, no. of installments, installment frequency for the purchase that the customer is making.</param>
        /// <returns>The PaymentPlan created with all properties set.</returns>
        public PaymentPlan CreatePaymentPlan(InstallmentRequest installmentRequest)
        {
            PaymentPlan paymentPlan = new PaymentPlan();
            Guid guidPaymentPlan = Guid.NewGuid();
            paymentPlan.Id = guidPaymentPlan;
            paymentPlan.PurchaseAmount = installmentRequest.OrderAmount;
            
            List<Installment> lstInstallments = new List<Installment>();
            
            Installment installment = new Installment();
            decimal installmentAmount = installmentRequest.OrderAmount / installmentRequest.Installments;
            DateTime nxtDueDate = installmentRequest.StartDate.AddDays(installmentRequest.FrequencyOfInstallment);
            for (int i = 0; i < installmentRequest.Installments; i++)
            {
                
                Guid guidInstallment = Guid.NewGuid();
                lstInstallments.Add(new Installment { Amount = installmentAmount , DueDate = nxtDueDate, Id = guidInstallment }) ;
                nxtDueDate = nxtDueDate.AddDays(installmentRequest.FrequencyOfInstallment);
            }
            paymentPlan.Installments = lstInstallments;
            return paymentPlan;
        }
    }
}
