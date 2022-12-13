namespace Zip.InstallmentsService.infrastructure
{
    /// <summary>
    /// Used to hold database context for installment service
    /// </summary>
    public class InstallmentsServiceDbContext : DbContext
    {
        #region Constructor

        /// <summary>
        /// Creates instance of <see cref="InstallmentsServiceDbContext"/>
        /// </summary>
        /// <param name="options"><see cref="DbContextOptions"/></param>
        public InstallmentsServiceDbContext(DbContextOptions options) : base(options)
        {
        }

        #endregion

        #region DataSets

        /// <summary>
        /// Gets or sets the database set for <see cref="Installment"/>
        /// </summary>
        public DbSet<Installment> Installments { get; set; }

        /// <summary>
        /// Gets or sets the database set for <see cref="PaymentPlan"/>
        /// </summary>
        public DbSet<PaymentPlan> PaymentPlans { get; set; }

        #endregion
    }
}
