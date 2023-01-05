using Castle.Core.Configuration;
using InstallmentCalculationAPI.Controllers;
using InstallmentCalculationAPI.Interface;
using InstallmentCalculationAPI.Log;
using InstallmentCalculationAPI.Repository.RepositoryInterface;
using Moq;
using System;
using Xunit;

namespace Zip.InstallmentsService.Test
{
    /// <summary>
    /// This test class covers all controller action methods
    /// </summary>
    public class InstallmentCalculationControllerTest:MockData
    {
        /// <summary>
        /// Creating mocked objects
        /// </summary>
        private readonly Mock<IInstallmentCalculator> calculator;
        private readonly Mock<IPaymentPlanFactory> paymentPlanFactory;
        private readonly Mock<IConfiguration> configuration;
        private readonly Mock<ICommandDataAccess> commandDataAccess;
        private readonly Mock<IQueryDataAccess> queryDataAccess;
        private readonly Mock<ILog> log;

        /// <summary>
        /// Initializing mocked objects
        /// </summary>
        public InstallmentCalculationControllerTest()
        {
            calculator = new Mock<IInstallmentCalculator>();
            paymentPlanFactory = new Mock<IPaymentPlanFactory>();
            configuration = new Mock<IConfiguration>();
            commandDataAccess = new Mock<ICommandDataAccess>();
            queryDataAccess = new Mock<IQueryDataAccess>();
            log = new Mock<ILog>();
        }

        /// <summary>
        /// This test case cover controller action method for creatin payment plan 
        /// </summary>
        [Fact]
        public void CreatePaymentPlanTest()
        {
            var installmentrequest = GetInstallmentRequest();
            var installmentResponse = GetInstallmentResponse();
            var queryData = GetPaymentPlan();
            calculator.Setup(x => x.CalculateInstallment(installmentrequest)).Returns(queryData);
            var controller = new InstallmentCalculationController(calculator.Object, log.Object);
            var result = controller.CreatePaymentPlan(installmentrequest);
            Assert.NotNull(result);
            Assert.Equal(installmentResponse.ResponseMessage, result.ResponseMessage);
            Assert.Equal(installmentResponse.PaymentPlan.Id, result.PaymentPlan.Id);
            Assert.Equal(installmentResponse.PaymentPlan.Installments.Count, result.PaymentPlan.Installments.Count);
        }

        /// <summary>
        /// This test case cover controller action method which fetch payment plan from given id.
        /// </summary>
        [Fact]
        public void GetInstallmentSummaryTest()
        {
            var queryData = GetPaymentPlan();
            calculator.Setup(x => x.GetInstallmentSummary(GetGuid())).Returns(queryData);
            var controller = new InstallmentCalculationController(calculator.Object,log.Object);
            var result = controller.GetInstallmentSummary(GetGuid());
            Assert.NotNull(result);
            Assert.Equal(queryData.PurchaseAmount, result.PaymentPlan.PurchaseAmount);
            Assert.Equal(queryData.Id, result.PaymentPlan.Id);
            Assert.Equal(queryData.Installments.Count,result.PaymentPlan.Installments.Count);
        }

        /// <summary>
        /// This test case cover when record does not exist
        /// </summary>
        [Fact]
        public void GetInstallmentSummaryTestFail()
        {
            var queryData = GetEmptyPaymentPlan();
            calculator.Setup(x => x.GetInstallmentSummary(GetRandomGuid())).Returns(queryData);
            var controller = new InstallmentCalculationController(calculator.Object, log.Object);
            var result = controller.GetInstallmentSummary(GetRandomGuid());
            Assert.Null(result.PaymentPlan);
            Assert.Equal("Payment plan could not found.", result.ResponseMessage);
            Assert.Equal(204, result.StatusCode);
            Assert.Equal(false, result.Status);
        }


    }
}
