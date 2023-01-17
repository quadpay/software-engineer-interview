using System;
namespace Zip.Installements.Contract.Response
{
    /// <summary>
    /// Class declares properties that are used as a response of payment installement details 
    /// </summary>
    public class InstallementDetailsResponse
    {
        /// <summary>
        /// Due date.
        /// </summary>
        public string DueDate { get; set; }

        /// <summary>
        /// Due amount.
        /// </summary>
        public decimal DueAmount { get; set; }

        /// <summary>
        /// Payment id.
        /// </summary>
        public int PaymentId { get; set; }
    }
}
