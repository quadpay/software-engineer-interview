namespace Zip.InstallmentsService.Web.StartupSetup
{
    /// <summary>
    /// Used to hold extension method for setting up logging
    /// </summary>
    public static class LoggingSetup
    {
        #region Public Method

        /// <summary>
        /// Add service dependencies for logging
        /// </summary>
        /// <param name="logging"><see cref="ILoggingBuilder"/></param>
        /// <param name="configuration"><see cref="IConfiguration"/></param>
        public static void AddLoggingSetup(this ILoggingBuilder logging, IConfiguration configuration)
        {
            var loggerConfig = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext()
                .CreateLogger();

            logging.ClearProviders();
            logging.AddSerilog(loggerConfig);
        }

        #endregion
    }
}
