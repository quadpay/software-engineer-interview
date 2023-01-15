using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zip.Installements.Contract.Response
{
    public class InstallementDetailsResponse
    {
        public string DueDate { get; set; }

        public decimal DueAmount { get; set; }

        public int PaymentId { get; set; }
    }
}
