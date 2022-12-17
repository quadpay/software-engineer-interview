using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zip.Installments.ViewModel.Orders
{
    public class OrdersViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string ProductId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public decimal PurchaseAmount { get; set; }
        public int NumberOfInstallments { get; set; }
        public int Frequency { get; set; }
        public DateTime FirstPaymentDate { get; set; }
    }
}
