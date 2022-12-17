using InstallmentCalculationAPI.BusinessLogic;
using InstallmentCalculationAPI.Interface;
using InstallmentRepository.RepositoryInterface;
using Microsoft.Extensions.Configuration;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Xunit;

namespace Zip.InstallmentsService.Test
{
    public class PaymentPlanFactoryTests
    {
        private readonly Mock<IGetInstallmentDetails> getInstallmentDetails;
        private readonly Mock<InstallmentCalculator> calculator;
        private readonly Mock<IPaymentPlanFactory> paymentPlanFactory;
        private readonly Mock<IConfiguration> configuration;
        private readonly Mock<ICommandDataAccess> commandDataAccess;
        SqlConnection con;
        public PaymentPlanFactoryTests()
        {
            getInstallmentDetails = new Mock<IGetInstallmentDetails>();
            calculator = new Mock<InstallmentCalculator>();
            paymentPlanFactory = new Mock<IPaymentPlanFactory>();
            configuration = new Mock<IConfiguration>();
            commandDataAccess = new Mock<ICommandDataAccess>();
        }

        [Fact]
        public void GetInstallmentSummary()
        {
            PaymentPlan plan = new PaymentPlan();
            var querydata = GetPaymentPlan();
            getInstallmentDetails.Setup(x => x.GetInstallmentSummary(new Guid("BBA85D17-3F6B-4839-B0C0-F1E3FAE7B454"))).Returns(querydata);

           // var installmentCalculator = new InstallmentCalculator(configuration, commandDataAccess, paymentPlanFactory);
        }

        [Fact]
        public void WhenCreatePaymentPlanWithValidOrderAmount_ShouldReturnValidPaymentPlan()
        {
            // Arrange
            var paymentPlanFactory = new PaymentPlanFactory();
            var paymentPlan = new PaymentPlan();
            // Act
            //  var paymentPlan = paymentPlanFactory.CreatePaymentPlan(123.45M);

            // Assert
            paymentPlan.ShouldNotBeNull();
        }

        private PaymentPlan GetPaymentPlan()
        {
            PaymentPlan paymentPlan = new PaymentPlan();
            paymentPlan.Id = new Guid("BBA85D17-3F6B-4839-B0C0-F1E3FAE7B454");
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

       // private ICommandDataAccess 
    }
}
