namespace ZipPayment.API.Middleware
{
    /// <summary>
    /// Create a MiddlewareExtensions
    /// </summary>
    public static class MiddlewareExtensions
    {
        /// <summary>
        /// Returns ExceptionHandlerMiddleware to handle custom exceptions
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
