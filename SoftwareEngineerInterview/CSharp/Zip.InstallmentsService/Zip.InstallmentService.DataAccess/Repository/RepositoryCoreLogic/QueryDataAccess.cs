using InstallmentCalculationAPI.Repository.RepositoryInterface;
using System.Data;
using System.Data.SqlClient;
using Zip.InstallmentService.DataAccess.Context;
using Zip.InstallmentsService;

namespace InstallmentCalculationAPI.Repository.RepositoryCoreLogic
{
    /// <summary>
    /// Core logic for Query data responsibility segeregation
    /// </summary>
    public class QueryDataAccess : IQueryDataAccess
    {
        private PaymentPlanContext _paymentPlanContext;
        public QueryDataAccess(PaymentPlanContext paymentPlanContext)
        {
            _paymentPlanContext = paymentPlanContext;
        }
        /// <summary>
        /// Get payment plan along with installment plan for given id
        /// </summary>
        /// <param name="guid">unique identifier for each payment plan</param>
        /// <param name="con">dwl connection object</param>
        /// <returns>Returns payment plan containing installment details</returns>
        public PaymentPlan GetAllPaymentPlan(Guid guid)
        {
            PaymentPlan plan = new PaymentPlan();
            plan.Installments = new List<Installment>();
            Installment installment;
            //LinQ query to fetch installment details using join
            var result = (from pp in _paymentPlanContext.PaymentPlan
                          join ins in _paymentPlanContext.Installments on pp.Id equals ins.PaymentPlanId
                         where pp.Id == guid
                         orderby ins.DueDate
                         select new { ins.PaymentPlanId, pp.PurchaseAmount, InstallmentAmount = ins.Amount, ins.DueDate, ins.Id }).ToList();
            foreach (var item in result)
            {
                installment = new Installment();
                plan.Id = item.PaymentPlanId;
                plan.PurchaseAmount = item.PurchaseAmount;
                installment.Amount = item.InstallmentAmount;
                installment.DueDate = item.DueDate;
                installment.Id = item.Id;
                plan.Installments.Add(installment);
            }
            
            return plan;
        }
    }
}
