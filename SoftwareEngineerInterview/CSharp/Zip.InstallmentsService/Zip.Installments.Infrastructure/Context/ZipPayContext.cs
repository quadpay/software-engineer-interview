namespace Zip.Installments.Infrastructure.Context
{
    using Zip.Installments.Domain.Entities;
    using Microsoft.EntityFrameworkCore;


    /// <summary>
    /// DbContext class for zip pay project
    /// </summary>
    public class ZipPayContext : DbContext
    {
        /// <summary>
        /// DbSet property
        /// Property use for query and save, update instance of payment
        /// </summary>
        public virtual DbSet<Payment> Payment { get; set; }

        /// <summary>
        /// DbSet property
        /// Property use for query and save, update instance of installementplan
        /// </summary>
        public virtual DbSet<InstallementPlan> InstallementPlan { get; set; }


        public ZipPayContext(DbContextOptions options) : base(options)
        {

        }

        /// <summary>
        /// Overriden method to load the entity configurations.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }

        /// <summary>
        /// Method to configure the behaviour of db context object.
        /// </summary>
        /// <param name="options"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //In memory database used for simplicity
            options.UseInMemoryDatabase("TestDb");
        }
    }
}
