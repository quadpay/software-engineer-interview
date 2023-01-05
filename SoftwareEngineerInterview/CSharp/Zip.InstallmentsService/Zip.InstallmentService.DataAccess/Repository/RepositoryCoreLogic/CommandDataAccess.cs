using InstallmentCalculationAPI.Repository.RepositoryInterface;
using System.Data;
using System.Data.SqlClient;
using Zip.InstallmentService.DataAccess.Context;
using Zip.InstallmentsService;


namespace InstallmentCalculationAPI.Repository.RepositoryCoreLogic
{
    /// <summary>
    /// Core logic for Command responsibility segeregation Repository
    /// </summary>
    public class CommandDataAccess : ICommandDataAccess
    {
        private PaymentPlanContext _paymentPlanContext;
        public CommandDataAccess(PaymentPlanContext paymentPlanContext)
        {
            _paymentPlanContext = paymentPlanContext;
        }
        /// <summary>
        /// Store Payment plan to Database
        /// </summary>
        /// <param name="paymentPlan">Payment plan calculated based on user input</param>
        /// <param name="con">sql connection object</param>
        /// <returns></returns>
        public bool StorePaymentPlan(PaymentPlan paymentPlan)
        {
            bool status = false;
            if (paymentPlan != null)
            {
                _paymentPlanContext.Add<PaymentPlan>(paymentPlan);
                _paymentPlanContext.SaveChanges();
                status = true;
            }
            return status;
        }
    }
}