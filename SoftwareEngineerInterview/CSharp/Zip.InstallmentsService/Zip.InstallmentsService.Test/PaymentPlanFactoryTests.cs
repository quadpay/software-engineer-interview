using InstallmentCalculationAPI.Interface;
using InstallmentCalculationAPI.Repository.RepositoryInterface;
using Microsoft.Extensions.Configuration;
using Moq;
using System.Data.SqlClient;
using System.Linq;
using Xunit;

namespace Zip.InstallmentsService.Test
{
    /// <summary>
    /// This class contains test cases for business logic
    /// </summary>
    public class PaymentPlanFactoryTests:MockData
    {
        /// <summary>
        /// mocking objects
        /// </summary>
        private readonly Mock<IInstallmentCalculator> calculator;
        private readonly Mock<IPaymentPlanFactory> paymentPlanFactory;
        private readonly Mock<IConfiguration> configuration;
        private readonly Mock<ICommandDataAccess> commandDataAccess;
        private readonly Mock<IQueryDataAccess> queryDataAccess;
        private readonly Mock<InstallmentRequest> installmentRequest;
        SqlConnection con;

        /// <summary>
        /// Initialize mocked objects
        /// </summary>
        public PaymentPlanFactoryTests()
        {
            calculator = new Mock<IInstallmentCalculator>();
            paymentPlanFactory = new Mock<IPaymentPlanFactory>();
            configuration = new Mock<IConfiguration>();
            commandDataAccess = new Mock<ICommandDataAccess>();
            queryDataAccess = new Mock<IQueryDataAccess>();
            installmentRequest = new Mock<InstallmentRequest>();
        }

        /// <summary>
        /// This test case cover creating payment plan based on input request
        /// </summary>
        [Fact]
        public void CreatePaymentPlanTest()
        {
            PaymentPlan paymentPlan = new PaymentPlan();
            var queryData = GetPaymentPlan();
            var installmentrequest = GetInstallmentRequest();
            paymentPlanFactory.Setup(x => x.CreatePaymentPlan(installmentrequest)).Returns(queryData);
            var paymentDataAccessmock = paymentPlanFactory.Object;
            var result = paymentDataAccessmock.CreatePaymentPlan(installmentrequest);
            Assert.NotNull(result);
            Assert.Equal(4, queryData.Installments.Count());
        }

        /// <summary>
        /// This test case cover calculating installment details
        /// </summary>
        [Fact]
        public void CalculateInstallmentTest()
        {
            var installmentrequest = GetInstallmentRequest();
            var queryData = GetPaymentPlan();
            calculator.Setup(x => x.CalculateInstallment(installmentrequest)).Returns(queryData);
            var calculatorMock = calculator.Object;
            var result = calculatorMock.CalculateInstallment(installmentrequest);
            Assert.NotNull(result);
            Assert.Equal(4, result.Installments.Count());
        }
        /// <summary>
        /// This test case cover fetch payment plan for given id
        /// </summary>
        [Fact]
        public void GetInstallmentSummaryBusinessLayerTest()
        {
            PaymentPlan plan = new PaymentPlan();
            var querydata = GetPaymentPlan();
            calculator.Setup(x => x.GetInstallmentSummary(GetGuid())).Returns(querydata);
            var calculatormock = calculator.Object;
            plan = calculatormock.GetInstallmentSummary(GetGuid());
            Assert.NotNull(plan);
            Assert.Equal(4, plan.Installments.Count());
        }

    }
}
