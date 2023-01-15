using System.ComponentModel.DataAnnotations;

namespace Zip.Installements.Contract.Request
{
    public class PaymentPlanRequest
    {
        [Required]
        public decimal Amount { get; set; }

        [Required]
        public int NumofInstallement { get; set; }

        [Required]
        public int Frequency { get; set; }
    }
}
