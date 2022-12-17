using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Zip.InstallmentsService.Models;

namespace Zip.Installments.DAL.AppContext
{
    /// <summary>
    ///     The database context Definition class.
    /// </summary>
    public class OrdersDbContext: DbContext
    {
        private readonly IConfiguration configuration;

        public OrdersDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("OrdersDb");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Order> Orders { get; set; }

    }
}
