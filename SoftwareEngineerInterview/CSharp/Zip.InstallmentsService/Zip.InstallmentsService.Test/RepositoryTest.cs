using InstallmentCalculationAPI.Interface;
using InstallmentCalculationAPI.Repository.RepositoryInterface;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Zip.InstallmentsService.Test
{
    /// <summary>
    /// This test class contains all test cases related to repository(DB) operations
    /// </summary>
    public class RepositoryTest:MockData
    {
        /// <summary>
        /// Creating mocked objects
        /// </summary>
        private readonly Mock<IInstallmentCalculator> calculator;
        private readonly Mock<IPaymentPlanFactory> paymentPlanFactory;
        private readonly Mock<IConfiguration> configuration;
        private readonly Mock<ICommandDataAccess> commandDataAccess;
        private readonly Mock<IQueryDataAccess> queryDataAccess;
        SqlConnection con;

        /// <summary>
        /// Initializing mocked objects
        /// </summary>
        public RepositoryTest()
        {
            calculator = new Mock<IInstallmentCalculator>();
            paymentPlanFactory = new Mock<IPaymentPlanFactory>();
            configuration = new Mock<IConfiguration>();
            commandDataAccess = new Mock<ICommandDataAccess>();
            queryDataAccess = new Mock<IQueryDataAccess>();
        }

        /// <summary>
        /// This test case cover get installment details for given id
        /// </summary>
        [Fact]
        public void GetInstallmentSummaryTest()
        {
            PaymentPlan plan = new PaymentPlan();
            var querydata = GetPaymentPlan();
            queryDataAccess.Setup(x => x.GetAllPaymentPlan(GetGuid())).Returns(querydata);
            var queryDataAccessmock = queryDataAccess.Object;
            plan = queryDataAccessmock.GetAllPaymentPlan(GetGuid());
            Assert.NotNull(plan);
            Assert.Equal(4, plan.Installments.Count());
        }

        /// <summary>
        /// This test case cover storing payment plan to DB
        /// </summary>
        [Fact]
        public void StorePaymentPlanTest()
        {
            bool status = true;
            var queryData = GetPaymentPlan();
            commandDataAccess.Setup(x => x.StorePaymentPlan(queryData)).Returns(status);
            var commandDataAccessMock = commandDataAccess.Object;
            var result = commandDataAccessMock.StorePaymentPlan(queryData);
            Assert.True(result);
        }
    }
}
