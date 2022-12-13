namespace Zip.InstallmentsService.Core.Extension
{
    /// <summary>
    /// Used hold extension methods for application builder
    /// </summary>
    public static class BuilderExtension
    {
        #region Public Method

        /// <summary>
        /// Adds service dependencies for core project
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection"/></param>
        public static void AddCore(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreatePaymentPlanCommand));
            services.AddAutoMapper(typeof(PaymentPlanProfile));
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreatePaymentPlanRequestValidator>());
        }

        #endregion
    }
}
