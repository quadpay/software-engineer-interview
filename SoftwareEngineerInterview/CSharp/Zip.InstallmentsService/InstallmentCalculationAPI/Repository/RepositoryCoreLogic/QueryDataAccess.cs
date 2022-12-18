using InstallmentCalculationAPI.Repository.RepositoryInterface;
using System.Data;
using System.Data.SqlClient;
using Zip.InstallmentsService;

namespace InstallmentCalculationAPI.Repository.RepositoryCoreLogic
{
    /// <summary>
    /// Core logic for Query data segeregation
    /// </summary>
    public class QueryDataAccess : IQueryDataAccess
    {
        /// <summary>
        /// Get payment plan along with installment plan for given id
        /// </summary>
        /// <param name="guid">unique identifier for each payment plan</param>
        /// <param name="con">dwl connection object</param>
        /// <returns>Returns payment plan containing installment details</returns>
        public PaymentPlan GetAllPaymentPlan(Guid guid,SqlConnection con)
        {
            PaymentPlan plan = new PaymentPlan();
            plan.Installments = new List<Installment>();
            Installment installment;
            //query to get payment plan and installments for payment plan
            string sql = "select ins.PaymentPlanId, pp.PurchaseAmount,ins.Amount as 'Installment Amount',ins.DueDate, ins.Id from PaymentPlan pp" +
                            " Inner Join Installments ins on pp.Id = ins.PaymentPlanId" +
                            " where pp.Id='"+guid+
                            "' order by ins.DueDate";
            SqlCommand cmd = new SqlCommand(sql, con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            //Read data and keep it in payment plan object
            while (sqlDataReader.Read())
            {
                installment = new Installment();
                plan.Id = (Guid)sqlDataReader["PaymentPlanId"];
                plan.PurchaseAmount = (decimal)sqlDataReader["PurchaseAmount"];
                installment.Amount = (decimal)sqlDataReader["Installment Amount"];
                installment.DueDate = (DateTime)sqlDataReader["DueDate"];
                installment.Id = (Guid)sqlDataReader["Id"];
                plan.Installments.Add(installment);

            }
            return plan;
        }
    }
}
