using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zip.Installements.Contract.Response
{
    public class PaymentInstallementDetailsResponse
    {
        public PaymentInstallementDetailsResponse()
        {
            this.Installements = new List<InstallementDetailsResponse>();
        }
        public int Id { get; set; }

        public decimal TotalAmount { get; set; }

        public List<InstallementDetailsResponse> Installements { get; set; }
    }
}
