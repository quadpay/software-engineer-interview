namespace Zip.Installements.Domain.Entities
{
    using Zip.Installements.Domain.BaseEntity;

    public class InstallementPlan : Entity
    {
        public DateTimeOffset DueDate { get; set; }

        public decimal DueAmount { get; set; }

        //Navigation property
        public virtual Payment Payment { get; set; }

        public int PaymentId { get; set; }
    }
}
