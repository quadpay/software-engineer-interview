using ZipPayment.API.Models;

namespace ZipPayment.API.Business.Services
{
    /// <summary>
    /// PaymentService interface to create a payment plan and instalments via business objects that 
    /// connect to the repository call to business logic creates a payment plan and map Database 
    /// Entity to DTo objects
    /// </summary>
    public interface IPaymentService
    {
        /// <summary>
        /// CreatePaymentPlan
        /// </summary>
        /// <param name="amount">purchase amount</param>
        /// <param name="noOfInstalments">noOfInstalments</param>
        /// <param name="frequencyInWeeks">frequencyInWeeks</param>
        /// <returns></returns>
        Task<PaymentPlanDto?> CreatePaymentPlan(decimal amount, int noOfInstalments, int frequencyInWeeks);

        /// <summary>
        /// Get Payment Plan Asynchronously for matched paymentId
        /// </summary>
        /// <param name="id">paymentId</param>
        /// <returns>PaymentPlanDto</returns>
        Task<PaymentPlanDto?> GetPaymentPlanAsync(Guid id);

        /// <summary>
        /// Get All Payment Plan Asynchronously 
        /// </summary>
        /// <returns>List of PaymentPlanDto</returns>
        Task<IEnumerable<PaymentPlanDto>> GetAllPaymentPlansAsync();
    }
}
