using System;
using System.Collections.Generic;
using System.Text;

namespace Zip.InstallmentsService.Entity.Response
{
    /// <summary>
    /// Data structure which defines all the properties for an installment.
    /// </summary>
    public class InstallmentResponseModel
    {
        /// <summary>
        /// Gets or sets the unique identifier for each installment.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the date that the installment payment is due.
        /// </summary>
        public DateTime DueDate { get; set; }

        /// <summary>
        /// Gets or sets the amount of the installment.
        /// </summary>
        public decimal Amount { get; set; }
    }
}
