namespace Zip.Installments.Domain.Entities
{
    using Zip.Installments.Domain.BaseEntity;

    /// <summary>
    /// Class declares properties of payment entity class.
    /// </summary>
    public class Payment : Entity
    {
        public Payment()
        {
            this.InstallementPlans = new HashSet<InstallementPlan>();
        }

        /// <summary>
        /// Actual amount.
        /// </summary>
        public decimal Amount { get; set; }

        //Navigation property
        public virtual ICollection<InstallementPlan> InstallementPlans { get; set; }
    }
}
