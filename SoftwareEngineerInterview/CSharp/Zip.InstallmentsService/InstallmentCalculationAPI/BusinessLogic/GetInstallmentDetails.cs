using InstallmentCalculationAPI.Interface;
using Zip.InstallmentsService;
using InstallmentRepository.RepositoryInterface;
using System.Data.SqlClient;

namespace InstallmentCalculationAPI.BusinessLogic
{
    public class GetInstallmentDetails : IGetInstallmentDetails
    {
        private readonly IQueryDataAccess _queryDataAccess;
        SqlConnection con;
        private readonly IConfiguration _configuration;
        public GetInstallmentDetails(IQueryDataAccess queryDataAccess,IConfiguration configuration)
        {
            _queryDataAccess = queryDataAccess;
            _configuration = configuration;
            con = new SqlConnection(_configuration.GetConnectionString("ConStr"));
        }

        public PaymentPlan GetInstallmentSummary(Guid guid)
        {
            PaymentPlan plan = new PaymentPlan();
            plan.Installments = new List<Installment>();
            Installment installment = new Installment();
            SqlDataReader sqlDataReader = _queryDataAccess.GetAllPaymentPlan(guid,con);
            while (sqlDataReader.Read())
            {
                plan.Id = (Guid)sqlDataReader["PaymentPlanId"];
                plan.PurchaseAmount = (decimal)sqlDataReader["PurchaseAmount"];
                installment.Amount = (decimal)sqlDataReader["Installment Amount"];
                installment.DueDate = (DateTime)sqlDataReader["DueDate"];
                plan.Installments.Add(installment);

            }

            return plan;
        }

    }
}
