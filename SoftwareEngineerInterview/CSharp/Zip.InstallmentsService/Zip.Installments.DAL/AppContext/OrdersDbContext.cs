using Microsoft.EntityFrameworkCore;
using Zip.Installments.DAL.Models;

namespace Zip.Installments.DAL.AppContext
{
    /// <summary>
    ///     The database context Definition class.
    /// </summary>
    public class OrdersDbContext : DbContext
    {
        /// <summary>
        ///     Initialize an db context instance
        /// </summary>
        /// <param name="options">The db options</param>
        public OrdersDbContext(DbContextOptions<OrdersDbContext> options) 
            : base(options)
        {
        }

        /// <summary>
        ///     Configure db options
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        /// <summary>
        ///     Db instance of orders
        /// </summary>
        public DbSet<Order> Orders { get; set; }

    }
}
