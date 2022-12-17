﻿namespace Zip.Installments.DAL.Models
{
    /// <summary>
    ///     The POCO definition of orders
    /// </summary>
    public class Order
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string ProductId { get; set; }        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int NumberOfInstallments { get; set; }
        public PaymentPlan Payment { get; set; }
    }
}