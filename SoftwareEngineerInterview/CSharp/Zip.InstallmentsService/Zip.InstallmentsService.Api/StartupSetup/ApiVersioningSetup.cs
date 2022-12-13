namespace Zip.InstallmentsService.Web.StartupSetup
{
    /// <summary>
    /// Used to hold extension method for setting up API versioning
    /// </summary>
    public static class ApiVersioningSetup
    {
        #region Public Method

        /// <summary>
        /// Add service dependencies for Api version
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection"/></param>
        public static void AddApiVersioningSetup(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
                options.ApiVersionReader = ApiVersionReader.Combine(
                    new UrlSegmentApiVersionReader(),
                    new HeaderApiVersionReader("Version"),
                    new MediaTypeApiVersionReader("Version"));
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
        }

        #endregion
    }
}
