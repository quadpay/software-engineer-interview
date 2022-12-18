using InstallmentCalculationAPI.Repository.RepositoryInterface;
using System.Data;
using System.Data.SqlClient;
using Zip.InstallmentsService;


namespace InstallmentCalculationAPI.Repository.RepositoryCoreLogic
{
    /// <summary>
    /// Core logic for Command responsibility segeregation Repository
    /// </summary>
    public class CommandDataAccess:ICommandDataAccess
    {
        /// <summary>
        /// Store Payment plan to Database
        /// </summary>
        /// <param name="paymentPlan">Payment plan calculated based on user input</param>
        /// <param name="con">sql connection object</param>
        /// <returns></returns>
        public bool StorePaymentPlan(PaymentPlan paymentPlan, SqlConnection con)
        {
            bool status = false;
            //Query to store payment plan into DB
            string sql = "Insert into PaymentPlan (Id, PurchaseAmount) Values('"+paymentPlan.Id+"',"+paymentPlan.PurchaseAmount+")";
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
               
                cmd.ExecuteNonQuery();
                status = StoreInstallmentDetails(paymentPlan.Installments, paymentPlan.Id, con);
            }
            catch (Exception)
            {

                status = false;
            }
            finally
            {
                con.Close();
            }
            return status;
        }
        /// <summary>
        /// Store installment details into DB
        /// </summary>
        /// <param name="installments">List of installments calculated</param>
        /// <param name="paymentPlanId">unique id for each payment plan</param>
        /// <param name="con"></param>
        /// <returns></returns>
        public bool StoreInstallmentDetails(List<Installment> installments, Guid paymentPlanId, SqlConnection con)
        {
            bool status = false;

            SqlCommand cmd;
            try
            {
                foreach (var item in installments)
                {
                    //Query to store installment into DB
                    string sql = "Insert into Installments (Id, DueDate, Amount, PaymentPlanId) Values('" + item.Id + "','" + item.DueDate.ToString("MM-dd-yyyy") + "',"+item.Amount+",'"+ paymentPlanId+"')";
                    cmd = new SqlCommand(sql, con);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    cmd.ExecuteNonQuery();
                    status = true;
                }

            }
            catch (Exception)
            {

                status = false;
            }
            finally { con.Close(); }
            return status;
        }

    }
}