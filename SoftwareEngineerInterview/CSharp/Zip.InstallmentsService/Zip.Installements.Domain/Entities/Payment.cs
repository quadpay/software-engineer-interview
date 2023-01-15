namespace Zip.Installements.Domain.Entities
{
    using Zip.Installements.Domain.BaseEntity;

    public class Payment : Entity
    {
        public Payment()
        {
            this.InstallementPlans = new HashSet<InstallementPlan>();
        }
        public decimal Amount { get; set; }

        //Navigation property
        public virtual ICollection<InstallementPlan> InstallementPlans { get; set; }
    }
}
