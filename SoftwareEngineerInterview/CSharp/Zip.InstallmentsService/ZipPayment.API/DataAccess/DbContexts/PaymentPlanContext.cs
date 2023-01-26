using Microsoft.EntityFrameworkCore;
using ZipPayment.API.DataAccess.Entities;

namespace ZipPayment.API.DataAccess.DbContexts
{
    /// <summary>
    /// Class PaymentPlanContext represents the database a gateway for query and save payment entity in the database
    /// </summary>
    public class PaymentPlanContext : DbContext
    {
        /// <summary>
        /// Query and save payment entity in the database
        /// </summary>
        public DbSet<PaymentPlanEntity> PaymentPlans { get; set; } = null!;

        /// <summary>
        /// Constructor: Create an instance of the PaymentPlanContext object with connecting string to connect SQLite database
        /// </summary>
        /// <param name="options">DbContextOptions</param>
        public PaymentPlanContext(DbContextOptions<PaymentPlanContext> options):base(options)
        {
        }
    }
}
