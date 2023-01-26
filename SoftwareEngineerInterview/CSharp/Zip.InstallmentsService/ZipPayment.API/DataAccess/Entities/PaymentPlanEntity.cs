using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZipPayment.API.DataAccess.Entities
{
    /// <summary>
    /// A Class defines all the properties for an payment plan to save in the database
    /// </summary>
    public class PaymentPlanEntity
    {
        /// <summary>
        /// Id uniquely identify the payment plan for the amount
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Total amount for the purchase
        /// </summary>
        [Required]
        [Range(1, 1000000)]
        public decimal PurchaseAmount { get; set; }

        /// <summary>
        /// Installments for the purchase that the customer is making.
        /// </summary>
        public ICollection<InstallmentEntity> Installments { get; set; } = new List<InstallmentEntity>();

        /// <summary>
        /// Constructor: PaymentPlanEntity initialize with purchase amount
        /// </summary>
        /// <param name="purchaseAmount"></param>
        public PaymentPlanEntity(decimal purchaseAmount)
        {
            PurchaseAmount = purchaseAmount;
            Id = Guid.NewGuid();
        }
    }
}
