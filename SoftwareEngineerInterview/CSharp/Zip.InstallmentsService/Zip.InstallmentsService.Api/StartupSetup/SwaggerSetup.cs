namespace Zip.InstallmentsService.Web.StartupSetup
{
    /// <summary>
    /// Used to hold extension method for setting up swagger
    /// </summary>
    public static class SwaggerSetup
    {
        #region Public Method

        /// <summary>
        /// Add service dependencies for swagger
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection"/></param>
        public static void AddSwaggerSetup(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "V1",
                    Title = "Payment Plan API",
                    Description = "API for creating and retriving payment plans",
                    Contact = new OpenApiContact()
                    {
                        Name = "Vishwajeet Velapurkar",
                        Email = "vishwajeetvelapurkar@gmail.com"
                    }
                });

                var xmlPath = Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml");
                options.IncludeXmlComments(xmlPath);
            });
        }

        #endregion
    }
}
