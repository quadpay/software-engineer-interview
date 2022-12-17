using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Zip.Installments.DAL.Models;

namespace Zip.Installments.DAL.AppContext
{
    /// <summary>
    ///     The database context Definition class.
    /// </summary>
    public class OrdersDbContext: DbContext
    {
        private readonly IConfiguration configuration;

        public OrdersDbContext(DbContextOptions<OrdersDbContext> options):base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Order> Orders { get; set; }

    }
}
