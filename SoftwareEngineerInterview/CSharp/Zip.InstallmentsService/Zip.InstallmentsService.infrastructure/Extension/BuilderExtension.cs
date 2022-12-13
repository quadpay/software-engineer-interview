namespace Zip.InstallmentsService.infrastructure.Extension
{
    /// <summary>
    /// Used hold extension methods for application builder
    /// </summary>
    public static class BuilderExtension
    {
        #region Public Methods

        /// <summary>
        /// Adds service dependencies for infrastructure project
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection"/></param>
        /// <param name="configuration"><see cref="IConfiguration"/></param>
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<InstallmentsServiceDbContext>(option =>
            {
                option.UseInMemoryDatabase(configuration.GetConnectionString("InstallmentServiceInMemoryDatabase"));
            });

            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
        }

        #endregion
    }
}
