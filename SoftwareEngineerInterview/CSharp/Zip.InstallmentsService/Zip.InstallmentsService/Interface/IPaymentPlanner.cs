
using System.Collections.Generic;
using Zip.InstallmentsService.DomainObjects;

namespace Zip.InstallmentsService.Interface
{
    /// <summary>
    /// Interface for Payment plan and create installments
    /// </summary>
    public interface IPaymentPlanner
    {
        /// <summary>
        /// Get a Payment plan based on noOfInstalments and frequencyInWeeks
        /// </summary>
        /// <param name="noOfInstalments">noOfInstalments</param>
        /// <param name="frequencyInWeeks">frequencyInWeeks</param>
        /// <returns>list of installment details</returns>
        IEnumerable<Installment> GetPaymentPlan(int noOfInstalments, int frequencyInWeeks);
    }
}
