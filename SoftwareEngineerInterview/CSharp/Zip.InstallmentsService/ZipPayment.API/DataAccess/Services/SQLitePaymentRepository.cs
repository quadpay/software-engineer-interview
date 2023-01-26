using Microsoft.EntityFrameworkCore;
using ZipPayment.API.DataAccess.DbContexts;
using ZipPayment.API.DataAccess.Entities;

namespace ZipPayment.API.DataAccess.Services
{
    /// <summary>
    /// Class SQLitePaymentRepository to query and save payment and installment entities in SQLite database
    /// </summary>
    public class SQLitePaymentRepository : IPaymentRepository
    {
        private readonly PaymentPlanContext _context;

        /// <summary>
        /// Constructor: Initialize SQLitePaymentRepository object with dbContext
        /// </summary>
        /// <param name="context"></param>
        public SQLitePaymentRepository(PaymentPlanContext context)
        {
            _context = context;
        }

        /// <summary>
        ///  Get installment asynchronously from database for given installment id
        /// </summary>
        /// <param name="id">installmentId</param>
        /// <returns>Installment</returns>
        public Task<InstallmentEntity?> GetInstallmentAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get all installments asynchronously from database
        /// </summary>
        /// <returns>List of Installments</returns>
        public Task<IEnumerable<InstallmentEntity>> GetInstallmentsAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get payment plan asynchronously from database for given payment plan id
        /// </summary>
        /// <param name="id">paymentPlanId</param>
        /// <returns>PaymentPlan</returns>
        public async Task<PaymentPlanEntity?> GetPaymentPlanAsync(Guid id)
        {
            return await _context.PaymentPlans.Include(t => t.Installments).Where(t => t.Id.Equals(id)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Get all payment plans asynchronously from database
        /// </summary>
        /// <returns>List of PaymentPlan</returns>
        public async Task<IEnumerable<PaymentPlanEntity>> GetPaymentPlansAsync()
        {
            return await _context.PaymentPlans.Include(t => t.Installments).ToListAsync();
        }

        /// <summary>
        /// Add Payment plan in to database
        /// </summary>
        /// <param name="paymentPlan">paymentPlan</param>
        /// <returns>Task</returns>
        public async Task AddPaymentPlan(PaymentPlanEntity paymentPlan)
        {
            await _context.PaymentPlans.AddAsync(paymentPlan);
        }

        /// <summary>
        /// Save changes in to database
        /// </summary>
        /// <returns>True/False</returns>
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
