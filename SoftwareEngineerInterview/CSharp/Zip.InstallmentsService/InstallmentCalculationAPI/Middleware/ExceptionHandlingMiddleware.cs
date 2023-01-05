

using InstallmentCalculationAPI.Log;
using System.Net;
using System.Text.Json;
using Zip.InstallmentsService.Model;

namespace InstallmentCalculationAPI.Middleware
{
    /// <summary>
    /// Centralised middleware exception class
    /// </summary>
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly ILog _logger;
        public ExceptionHandlingMiddleware(RequestDelegate requestDelegate, ILog logger)
        {
            _requestDelegate = requestDelegate;
            _logger = logger;

        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _requestDelegate(httpContext);
            }
            catch (Exception ex)
            {

               await HandleException(httpContext, ex); 
            }
        }

        private async Task HandleException(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "application/json";
            var errorresponse = new ErrorResponse
            {
                Success = false,
            };

            switch (exception)
            {
                case ApplicationException ex:
                    errorresponse.StatusCode = (int)HttpStatusCode.BadRequest;
                    errorresponse.Message = ex.Message;
                    break;
                case KeyNotFoundException ex:
                    errorresponse.StatusCode= (int)HttpStatusCode.NotFound;
                    errorresponse.Message= ex.Message;
                    break;
                default:
                    errorresponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                    errorresponse.Message= ("Internal server error. Check logs for more details");
                    break;
            }
            _logger.Error(exception.Message+" Stack Trace: "+exception.StackTrace);
            var result = JsonSerializer.Serialize(errorresponse);
            httpContext.Response.StatusCode = errorresponse.StatusCode;
            await httpContext.Response.WriteAsync(result);
        }

    }
}
