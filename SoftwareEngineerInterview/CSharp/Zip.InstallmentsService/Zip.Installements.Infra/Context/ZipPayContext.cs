namespace Zip.Installements.Infrastructure.Context
{
    using Zip.Installements.Domain.Entities;
    using Microsoft.EntityFrameworkCore;


    /// <summary>
    /// DbContext class for zip pay project
    /// </summary>
    public class ZipPayContext : DbContext
    {
        /// <summary>
        /// DbSet property
        /// Property use for query and save, update instance of user
        /// </summary>
        public virtual DbSet<Payment> Payment { get; set; }

        /// <summary>
        /// DbSet property
        /// Property use for query and save, update instance of account
        /// </summary>
        public virtual DbSet<InstallementPlan> InstallementPlan { get; set; }


        public ZipPayContext(DbContextOptions options) : base(options)
        {

        }

        /// <summary>
        /// Overriden method to load the entity configurations
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //In memory database used for simplicity
            options.UseInMemoryDatabase("TestDb");
        }
    }
}
