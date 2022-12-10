using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Zip.InstallmentsService.Data.Interface;
using Zip.InstallmentsService.Interface;

namespace Zip.InstallmentsService.Core.Test
{
    [TestClass]
    public class TestInitializer
    {
        public static HttpClient TestHttpClient;
        public static Mock<IPaymentPlanProvider> MockPaymentPlanProvider;
        public static Mock<IPaymentPlanRepository> MockPaymentPlanRepository;
        public static Mock<IInstallmentProvider> MockInstallmentProvider;

        //services.AddScoped<IPaymentPlanProvider, PaymentPlanProvider>();
        //    services.AddScoped<IPaymentPlanRepository, PaymentPlanRepository>();
        //    services.AddScoped<IInstallmentProvider, InstallmentProvider>();

        [AssemblyInitialize]
        public static void InitializeTestServer(TestContext testContext)
        {
            var testServer = new TestServer(new WebHostBuilder()
               .UseStartup<TestStartup>()
               // this would cause it to use StartupIntegrationTest class
               // or ConfigureServicesIntegrationTest / ConfigureIntegrationTest
               // methods (if existing)
               // rather than Startup, ConfigureServices and Configure
               .UseEnvironment("IntegrationTest"));

            TestHttpClient = testServer.CreateClient();
        }

        public static void RegisterMockRepositories(IServiceCollection services)
        {
            MockPaymentPlanProvider = (new Mock<IPaymentPlanProvider>());
            services.AddSingleton(MockPaymentPlanProvider.Object);

            //add more mock repositories below
            MockPaymentPlanRepository = (new Mock<IPaymentPlanRepository>());
            services.AddSingleton(MockPaymentPlanRepository.Object);

            MockInstallmentProvider = (new Mock<IInstallmentProvider>());
            services.AddSingleton(MockInstallmentProvider.Object);
        }
    }
}
