using System;
namespace Zip.Installements.Contract.Response
{
    public class InstallementDetailsResponse
    {
        public string DueDate { get; set; }

        public decimal DueAmount { get; set; }

        public int PaymentId { get; set; }
    }
}
