using InstallmentRepository.RepositoryInterface;
using System.Data;
using System.Data.SqlClient;

namespace InstallmentRepository.RepositoryCoreLogic
{
    public class QueryDataAccess : IQueryDataAccess
    {
        public SqlDataReader GetAllPaymentPlan(Guid guid,SqlConnection con)
        {
            string sql = "select ins.PaymentPlanId, pp.PurchaseAmount,ins.Amount as 'Installment Amount',ins.DueDate from PaymentPlan pp" +
                            " Inner Join Installments ins on pp.Id = ins.PaymentPlanId" +
                            " where pp.Id='"+guid+
                            "' order by ins.PaymentPlanId";
            SqlCommand cmd = new SqlCommand(sql, con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
    }
}
