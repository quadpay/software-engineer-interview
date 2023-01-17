namespace Zip.Installements.Domain.Entities
{
    using Zip.Installements.Domain.BaseEntity;

    /// <summary>
    /// Class declares properties of intallementplan entity class.
    /// </summary>
    public class InstallementPlan : Entity
    {
        /// <summary>
        /// Due date.
        /// </summary>
        public DateTimeOffset DueDate { get; set; }

        /// <summary>
        /// Due amount.
        /// </summary>
        public decimal DueAmount { get; set; }

        //Navigation property
        public virtual Payment Payment { get; set; }

        public int PaymentId { get; set; }
    }
}
