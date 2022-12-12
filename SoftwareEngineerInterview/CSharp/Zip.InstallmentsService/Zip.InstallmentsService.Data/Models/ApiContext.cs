using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zip.InstallmentsService.Data.Models
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public DbSet<PaymentPlan> PaymentPlans { get; set; }

        public DbSet<Installment> Installments { get; set; }
    }
}
