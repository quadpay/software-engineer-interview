using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace Zip.InstallmentsService.Dto
{
    /// <summary>
    /// Data structure which defines all the properties for an installment.
    /// </summary>
    public class Installment
    {
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for each installment.
        /// </summary>
        [Range(5,20)]        
        public string PaymentPlanId { get; set; }

        /// <summary>
        /// Gets or sets the date that the installment payment is due.
        /// </summary>
        public DateTime DueDate { get; set; }

        /// <summary>
        /// Gets or sets the amount of the installment.
        /// </summary>

        [PrecisionAttribute(10, 3)]
        public decimal Amount { get; set; }
    }
}
