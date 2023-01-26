using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZipPayment.API.DataAccess.Entities
{
    /// <summary>
    /// A Class defines all the properties for an installment to save in the database
    /// </summary>
    public class InstallmentEntity
    {
        /// <summary>
        /// Id uniquely identify the Installment for the payment
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Installment due date
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; } = DateTime.Now.Date;

        /// <summary>
        /// Amount of installment
        /// </summary>
        [Required]
        [Range(1, 1000000)]
        public decimal Amount { get; set; }

        /// <summary>
        /// Foreign key relation to payment plan
        /// </summary>
        [ForeignKey("PaymentPlanEntityId")]
        public PaymentPlanEntity? PaymentPlan { get; set; }

        /// <summary>
        /// Payment Plan reference key entity id
        /// </summary>
        public Guid PaymentPlanEntityId { get; set; }

        /// <summary>
        /// Constructor: InstallmentEntity initialize with installment amount
        /// </summary>
        /// <param name="amount"></param>
        public InstallmentEntity(decimal amount)
        {
            Id = Guid.NewGuid();
            Amount = amount;
        }
    }
}
