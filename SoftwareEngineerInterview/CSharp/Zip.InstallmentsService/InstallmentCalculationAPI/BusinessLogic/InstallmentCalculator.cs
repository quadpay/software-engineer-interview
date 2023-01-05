using InstallmentCalculationAPI.Interface;
using InstallmentCalculationAPI.Repository.RepositoryInterface;
using System.Data;
using System.Data.SqlClient;
using Zip.InstallmentsService;

namespace InstallmentCalculationAPI.BusinessLogic
{
    /// <summary>
    /// Core logic to Calculate payment installment and fetch payment plan from DB.
    /// </summary>
    public class InstallmentCalculator:IInstallmentCalculator
    {
        /// <summary>
        /// Declaring object to be passed in contructor for dependency
        /// </summary>
        SqlConnection con;
        private readonly IConfiguration _configuration;
        private readonly ICommandDataAccess _commandDataAccess;
        private readonly IPaymentPlanFactory _paymentPlanFactory;
        private readonly IQueryDataAccess _queryDataAccess;
        /// <summary>
        /// initialising interface objects
        /// </summary>
        /// <param name="configuration">SQl configuration</param>
        /// <param name="commandDataAccess"> Command data access object</param>
        /// <param name="paymentPlanFactory">play ment plan factory object</param>
        /// <param name="queryDataAccess">Query data access object</param>
        public InstallmentCalculator(IConfiguration configuration,ICommandDataAccess commandDataAccess,IPaymentPlanFactory paymentPlanFactory,IQueryDataAccess queryDataAccess)
        {
            _configuration = configuration;
            _commandDataAccess = commandDataAccess;
            _paymentPlanFactory = paymentPlanFactory;
            _queryDataAccess = queryDataAccess;
            //con = new SqlConnection(_configuration.GetConnectionString("ConStr")); //Get connection string from appsetting.json
        }
        /// <summary>
        /// Calculate payment installment
        /// </summary>
        /// <param name="installmentRequest">user input required to calculate payment installment</param>
        /// <returns>Calculated payment plan</returns>
        public PaymentPlan? CalculateInstallment(InstallmentRequest installmentRequest)
        {
            bool status = false;
            PaymentPlan paymentPlan = new PaymentPlan();
            //try
            //{
                //calculate payment plan
                paymentPlan =  _paymentPlanFactory.CreatePaymentPlan(installmentRequest);
                //pass calculated payment plan to command data access of repository
                status = _commandDataAccess.StorePaymentPlan(paymentPlan);
                if (status)
                {
                    return paymentPlan;
                }
                else
                {
                    return null;
                }
            //}
            //catch (Exception ex)
            //{

            //    throw;
            //}
            //finally 
            //{ 
            //    if(con.State == ConnectionState.Open)
            //    {
            //        con.Close();
            //    }
            // }
        }
        /// <summary>
        /// Get payment plan along with installment summary
        /// </summary>
        /// <param name="guid">unique identifier for payment plan</param>
        /// <returns>payment plan along with installment details</returns>
        public PaymentPlan? GetInstallmentSummary(Guid guid)
        {
            PaymentPlan? plan;
            //try
            //{
                //Make call to query data access to get payment plan
                plan = _queryDataAccess.GetAllPaymentPlan(guid);
            
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
            //finally
            //{
            //    //if (con.State == ConnectionState.Open)
            //    //{
            //    //    con.Close();
            //    //}
            //}

            return plan;
        }

    }
}
