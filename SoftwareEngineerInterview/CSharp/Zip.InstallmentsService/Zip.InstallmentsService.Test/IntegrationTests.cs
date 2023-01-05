//using InstallmentCalculationAPI.Controllers;
//using InstallmentCalculationAPI.Interface;
//using InstallmentCalculationAPI.Log;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Mvc.Testing;
////using Microsoft.VisualStudio.TestPlatform.TestHost;
//using System.Net.Http;
//using Xunit;

//namespace Zip.InstallmentsService.Test
//{
//    public class IntegrationTests:MockData
//    {
//        private readonly HttpClient _httpclient;
//        private readonly InstallmentCalculationController _installmentCalculationController;
//        private static readonly string[] args;
//        private  IInstallmentCalculator _installmentCalculator;
//        private  ILog _log;
//        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

//       // LogManager.LoadConfiguration(System.String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
//        public IntegrationTests(IInstallmentCalculator installmentCalculator,ILog log)
//        {
//            var appFactory = new WebApplicationFactory<Program>();
//            _httpclient = appFactory.CreateClient();
//            _installmentCalculator = installmentCalculator;
//            _log = log;
//            _installmentCalculationController = new InstallmentCalculationController(_installmentCalculator, _log);

//        }
//        [Fact]
//        public void CreatePaymentInstallment_IntTest()
//        {
//            var guid = GetGuid();
//            InstallmentResponse installmentResponse = new InstallmentResponse();
//             //var controller = new InstallmentCalculationController();
//            installmentResponse = _installmentCalculationController.GetInstallmentSummary(guid);
//        }
//    }
//}
