using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using Zip.InstallmentsService.Data.Interface;
using Zip.InstallmentsService.Data.Models;
using Zip.InstallmentsService.Data.Repository;
using Zip.InstallmentsService.Entity.Dto;
using Zip.InstallmentsService.Core.Implementation;
using Zip.InstallmentsService.Core.Interface;

namespace Zip.InstallmentsService.Core.Test
{
    [TestClass]
    public class PaymentPlanProviderTest
    {

        [TestMethod]
        public void WhenCreatePaymentPlanWithValidOrderAmount_ShouldReturnValidPaymentPlan()
        {
            // Arrange
            CreatePaymentPlanDto request = this.MockRequestObject(4, 14);
            PaymentPlanDto responseObj = this.MockResponseObject(request.Id, request.UserId, request.PurchaseDate, request.NoOfInstallments, request.FrequencyInDays);

            //Act
            var MockPaymentPlanProvider = TestInitializer.MockPaymentPlanProvider;
            MockPaymentPlanProvider.Setup
                  (x => x.Create(request)).Returns(responseObj);

            // Assert
            Assert.AreNotEqual(null, responseObj);
        }

        [TestMethod]
        public void WhenCreatePaymentPlanWithInValidRequest_ShouldReturnNull()
        {
            // Arrange
            CreatePaymentPlanDto request = this.MockRequestObject(0, 0);
            PaymentPlanDto responseObj = null;

            //Act
            var MockPaymentPlanProvider = TestInitializer.MockPaymentPlanProvider;
            MockPaymentPlanProvider.Setup
                  (x => x.Create(request)).Returns(responseObj);

            // Assert
            Assert.AreEqual(null, responseObj);
        }

        private CreatePaymentPlanDto MockRequestObject(int noOfInstallments, int frequencyInDays)
        {
            CreatePaymentPlanDto request = new CreatePaymentPlanDto()
            {
                Id = Guid.NewGuid(),
                UserId = Guid.Parse("504A683D-B4C3-4770-962B-4B5F3F89BB91"),
                PurchaseDate = DateTime.UtcNow,
                NoOfInstallments = noOfInstallments,
                FrequencyInDays = frequencyInDays
            };
            return request;
        }
        private PaymentPlanDto MockResponseObject(Guid id, Guid userId, DateTime date, int noOfInstallments, int frequencyInDays)
        {
            PaymentPlanDto response = new PaymentPlanDto()
            {
                Id = Guid.NewGuid(),
                UserId = Guid.Parse("504A683D-B4C3-4770-962B-4B5F3F89BB91"),
                PurchaseDate = DateTime.UtcNow,
                NoOfInstallments = noOfInstallments,
                FrequencyInDays = frequencyInDays
            };

            return response;
        }

    }
}
