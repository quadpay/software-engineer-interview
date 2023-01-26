using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zip.InstallmentsService.DomainObjects;
using ZipPayment.API.DataAccess.Entities;
using ZipPayment.API.Models;

namespace Zip.InstallmentsService.Test.TestHelpers
{
    internal static class TestHelper
    {
        public static List<Installment> GetInstallments(Guid[] installmentIds, decimal purchaseAmount, int noOfFrequency)
        {
            var installments = new List<Installment>();
            var dueDate = DateTime.Now.Date;
            foreach (var installmentId in installmentIds)
            {
                var newInstallment = new Installment()
                {
                    Id = installmentId,
                    Amount = purchaseAmount/ installmentIds.Length,
                    DueDate = dueDate,
                 };
                dueDate = DateTime.Now.AddDays(noOfFrequency*7);
                installments.Add(newInstallment);
            }

            return installments;
        }

        public static List<PaymentPlanDto> GetTestPaymentPlans()
        {
            return new List<PaymentPlanDto>
            {
                new PaymentPlanDto{
                    Id = Guid.NewGuid(),
                    PurchaseAmount =500M,
                    Installments = new List<InstallmentDto>
                    {
                        new InstallmentDto
                        {
                            Id = Guid.NewGuid(),
                            Amount =100M,
                            DueDate = DateTime.Now.AddDays(7).Date
                        }
                    }
                }
            };
        }

        public static List<PaymentPlanEntity> GetTestPaymentPlanEntities(decimal purchaseAmount, decimal installmentAmount)
        {
            return new List<PaymentPlanEntity>
            {
                new PaymentPlanEntity(purchaseAmount){
                    Installments = new List<InstallmentEntity>
                    {
                        new InstallmentEntity(installmentAmount)
                        {
                            DueDate = DateTime.Now.AddDays(7).Date
                        }
                    }
                }
            };
        }

        public static PaymentPlanDto GetTestPaymentPlanById(Guid guid)
        {
            return new PaymentPlanDto
            {
                Id = guid,
                PurchaseAmount = 500M,
                Installments = new List<InstallmentDto>
                    {
                        new InstallmentDto
                        {
                            Id = Guid.NewGuid(),
                            Amount =100M,
                            DueDate = DateTime.Now.AddDays(7).Date
                        }
                    }
            };
        }
    }
}
