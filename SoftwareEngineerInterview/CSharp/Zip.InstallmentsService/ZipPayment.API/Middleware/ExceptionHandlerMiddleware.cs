using System.Net;
using System.Text.Json;

namespace ZipPayment.API.Middleware
{
    /// <summary>
    /// ExceptionHandlerMiddleware handles the unhandled exception and translate in to appropriate http status code 
    /// </summary>
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;
        /// <summary>
        /// Constructor: initialize with next middleware handler
        /// </summary>
        /// <param name="next">RequestDelegate</param>
        /// <param name="logger">logger</param>
        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        /// <summary>
        /// Invoke the next handler in the http pipeline request
        /// </summary>
        /// <param name="context">HttpContext</param>
        /// <returns>Task</returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await ConvertException(context, ex);
            }
        }

        /// <summary>
        /// Convert unhandeld exception in to appropriate HttpStatusCode
        /// </summary>
        /// <param name="context"></param>
        /// <param name="ex"></param>
        /// <returns>error message</returns>
        private async Task ConvertException(HttpContext context, Exception ex)
        {
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            var result = string.Empty;
            switch (ex)
            {
                case BadHttpRequestException badHttpRequestException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    result = badHttpRequestException.Message;
                    break;

                case ApplicationException applicationException:
                    httpStatusCode = HttpStatusCode.Forbidden;
                    result = applicationException.Message;
                    break;

                default:
                    result = "A problem happened while handling your request.";
                    httpStatusCode = HttpStatusCode.InternalServerError;
                    break;
            }

            _logger.LogError(ex.Message);
            context.Response.StatusCode = (int)httpStatusCode;

            await context.Response.WriteAsync(JsonSerializer.Serialize(new { error = result }));
        }
    }
}
