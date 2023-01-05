using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zip.InstallmentsService;

namespace Zip.InstallmentService.DataAccess.Context
{
    /// <summary>
    /// This is DB context class for Payment plan
    /// </summary>
    public class PaymentPlanContext:DbContext
    {
        public PaymentPlanContext(DbContextOptions<PaymentPlanContext> options):base(options)
        {

        }
        /// <summary>
        /// Get or set payment plan data model
        /// </summary>
        public DbSet<PaymentPlan> PaymentPlan { get; set; }
        /// <summary>
        /// Get or set Installments data model
        /// </summary>
        public DbSet<Installment> Installments { get; set; }
    }
}
