using InstallmentRepository.RepositoryInterface;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Zip.InstallmentsService;


namespace InstallmentRepository
{
    /// <summary>
    /// To Store payment plan to database
    /// </summary>
    public class CommandDataAccess:ICommandDataAccess
    {
        
        public bool StorePaymentPlan(PaymentPlan paymentPlan, SqlConnection con)
        {
            bool status = false;
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

        public bool StoreInstallmentDetails(List<Installment> installments, Guid paymentPlanId, SqlConnection con)
        {
            bool status = false;

            SqlCommand cmd;
            try
            {
                foreach (var item in installments)
                {
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