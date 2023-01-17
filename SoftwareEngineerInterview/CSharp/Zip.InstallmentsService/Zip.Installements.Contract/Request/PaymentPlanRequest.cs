namespace Zip.Installements.Contract.Request
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class PaymentPlanRequest 
    {
        //[Required]
        //[Range(1, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public decimal Amount { get; set; }

        //[Required]
        //[Range(1, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]

        public int NumofInstallement { get; set; }

        //[Required]
        //[Range(1, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Frequency { get; set; }
    }
}
