using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Zip.InstallmentsService.Dto;

namespace Zip.InstallmentsService.Infrastructure.DBContext
{
    public class PaymentPlanDBContext : DbContext
    {
        public PaymentPlanDBContext(DbContextOptions<PaymentPlanDBContext> options) : base(options)
        {
        }

        public DbSet<Installment> installment { get; set; }    
    }
}
