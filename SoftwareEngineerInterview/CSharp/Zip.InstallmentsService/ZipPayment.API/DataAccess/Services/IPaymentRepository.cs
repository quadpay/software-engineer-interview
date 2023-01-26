
using ZipPayment.API.DataAccess.Entities;

namespace ZipPayment.API.DataAccess.Services
{
    /// <summary>
    /// PaymentRepository define business object interface for creating retreiving payment plans
    /// </summary>
    public interface IPaymentRepository
    {
        /// <summary>
        /// Get all payment plans asynchronously from database
        /// </summary>
        /// <returns>List of PaymentPlan</returns>
        Task<IEnumerable<PaymentPlanEntity>> GetPaymentPlansAsync();

        /// <summary>
        /// Get payment plan asynchronously from database for given payment plan id
        /// </summary>
        /// <param name="id">paymentPlanId</param>
        /// <returns>PaymentPlan</returns>
        Task<PaymentPlanEntity?> GetPaymentPlanAsync(Guid id);

        /// <summary>
        /// Get all installments asynchronously from database
        /// </summary>
        /// <returns>List of Installments</returns>
        Task<IEnumerable<InstallmentEntity>> GetInstallmentsAsync();

        /// <summary>
        ///  Get installment asynchronously from database for given installment id
        /// </summary>
        /// <param name="id">installmentId</param>
        /// <returns>Installment</returns>
        Task<InstallmentEntity?> GetInstallmentAsync(Guid id);

        /// <summary>
        /// Add Payment plan in to database
        /// </summary>
        /// <param name="paymentPlan">paymentPlan</param>
        /// <returns>Task</returns>
        Task AddPaymentPlan(PaymentPlanEntity paymentPlan);

        /// <summary>
        /// Save changes in to database
        /// </summary>
        /// <returns>True/False</returns>
        Task<bool> SaveChangesAsync();
    }
}
