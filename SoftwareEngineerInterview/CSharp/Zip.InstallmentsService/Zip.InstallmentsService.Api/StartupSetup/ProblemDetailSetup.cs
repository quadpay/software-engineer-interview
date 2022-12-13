namespace Zip.InstallmentsService.Web.StartupSetup
{
    /// <summary>
    /// Used to hold extension method for setting up problem detail
    /// </summary>
    public static class ProblemDetailSetup
    {
        #region Public Method

        /// <summary>
        /// Add service dependencies for logging
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection"/></param>
        /// <param name="environment"><see cref="IWebHostEnvironment"/></param>
        public static void AddProblemDetailSetup(this IServiceCollection services, IWebHostEnvironment environment)
        {
            services.AddProblemDetails(options =>
            {
                //Include error detail based for Development and Staging environment
                options.IncludeExceptionDetails = (ctx, env) => environment.IsDevelopment() || environment.IsStaging();
            });
        } 

        #endregion
    }
}
