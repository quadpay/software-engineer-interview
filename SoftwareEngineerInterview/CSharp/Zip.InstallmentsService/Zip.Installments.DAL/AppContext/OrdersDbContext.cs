using Microsoft.EntityFrameworkCore;
using Zip.Installments.DAL.Models;

namespace Zip.Installments.DAL.AppContext
{
    /// <summary>
    ///     The database context Definition class.
    /// </summary>
    public class OrdersDbContext : DbContext
    {
        public OrdersDbContext(DbContextOptions<OrdersDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Order>()
        //        .Property(n => n.Payment);
        //}

        public DbSet<Order> Orders { get; set; }

    }
}
