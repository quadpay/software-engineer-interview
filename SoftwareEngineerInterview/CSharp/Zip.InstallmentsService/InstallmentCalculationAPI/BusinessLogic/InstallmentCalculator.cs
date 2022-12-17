using InstallmentCalculationAPI.Interface;
using InstallmentRepository;
using InstallmentRepository.RepositoryInterface;
using System.Data.SqlClient;
using Zip.InstallmentsService;

namespace InstallmentCalculationAPI.BusinessLogic
{
    /// <summary>
    /// Calculate payment installment and store it to database.
    /// </summary>
    public class InstallmentCalculator:IInstallmentCalculator
    {
        SqlConnection con;
        private readonly IConfiguration _configuration;
        private readonly ICommandDataAccess _commandDataAccess;
        private readonly IPaymentPlanFactory _paymentPlanFactory;
        public InstallmentCalculator(IConfiguration configuration,ICommandDataAccess commandDataAccess,IPaymentPlanFactory paymentPlanFactory)
        {
            _configuration = configuration;
            _commandDataAccess = commandDataAccess;
            _paymentPlanFactory = paymentPlanFactory;
            con = new SqlConnection(_configuration.GetConnectionString("ConStr"));
        }
        public PaymentPlan CalculateInstallment(InstallmentRequest installmentRequest)
        {
            bool status = false;
            PaymentPlan paymentPlan = new PaymentPlan();
            try
            {
                paymentPlan =  _paymentPlanFactory.CreatePaymentPlan(installmentRequest);
                status = _commandDataAccess.StorePaymentPlan(paymentPlan, con);
            }
            catch (Exception ex)
            {

                throw;
            }
            return paymentPlan;
        }

    }
}
