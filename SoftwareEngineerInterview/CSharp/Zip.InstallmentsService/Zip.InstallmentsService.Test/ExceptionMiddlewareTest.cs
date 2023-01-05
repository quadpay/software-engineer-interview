using InstallmentCalculationAPI.Controllers;
using InstallmentCalculationAPI.Interface;
using InstallmentCalculationAPI.Log;
using InstallmentCalculationAPI.Middleware;
using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Zip.InstallmentsService.Test
{
    public class ExceptionMiddlewareTest:MockData
    {
        private readonly Mock<ILog> _log;
        private readonly Mock<RequestDelegate> _requestDelegate;
        private readonly Mock<ExceptionHandlingMiddleware> _exceptionHandlingMiddleware;
        private readonly Mock<IInstallmentCalculator> calculator;
        public ExceptionMiddlewareTest()
        {
            _log = new Mock<ILog>();
            _requestDelegate = new Mock<RequestDelegate>();
            _exceptionHandlingMiddleware = new Mock<ExceptionHandlingMiddleware>();
            calculator = new Mock<IInstallmentCalculator>();
        }
        [Fact]
        public async Task ExceptionHandlingMiddleware_InternalServer()
        {

            var expectedException = new ArgumentNullException();
            RequestDelegate mockNextMiddleware = (HttpContext) =>
            {
                return Task.FromException(expectedException);
            };
            var httpContext = new DefaultHttpContext();

            var exceptionHandlingMiddleware = new ExceptionHandlingMiddleware(mockNextMiddleware,_log.Object);

            //act
            await exceptionHandlingMiddleware.InvokeAsync(httpContext);

            //assert
            Assert.Equal(HttpStatusCode.InternalServerError, (HttpStatusCode)httpContext.Response.StatusCode);
        }

        [Fact]
        public async Task ExceptionHandlingMiddleware_Success()
        {
            //var exception = new KeyNotFoundException();
            var defaulthttpcontext = new DefaultHttpContext();
            //HttpContext defaulthttpcontext = null;
            //var httpcontext = GetKeynotFoundHttpContext();
            ////await _exceptionHandlingMiddleware.Setup(x => x.Invoke(defaulthttpcontext)).Returns(Task.CompletedTask);
            var middleware = new ExceptionHandlingMiddleware(_requestDelegate.Object, _log.Object);
            //throw new KeyNotFoundException();
            await middleware.InvokeAsync(defaulthttpcontext);
            //await middleware.Invoke(httpcontext);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)defaulthttpcontext.Response.StatusCode);
        }

        [Fact]
        public async Task ExceptionHandlingMiddleware_BadRequest()
        {
            var expectedException = new ApplicationException("test");
            RequestDelegate mockNextMiddleware = (HttpContext) =>
            {
                return Task.FromException(expectedException);
            };
            var httpContext = new DefaultHttpContext();

            var exceptionHandlingMiddleware = new ExceptionHandlingMiddleware(mockNextMiddleware, _log.Object);

            //act
            await exceptionHandlingMiddleware.InvokeAsync(httpContext);

            //assert
            Assert.Equal(HttpStatusCode.BadRequest, (HttpStatusCode)httpContext.Response.StatusCode);
        }

        [Fact]
        public async Task ExceptionHandlingMiddleware_KeyNotFound()
        {
            var expectedException = new KeyNotFoundException("test");
            RequestDelegate mockNextMiddleware = (HttpContext) =>
            {
                return Task.FromException(expectedException);
            };
            var httpContext = new DefaultHttpContext();

            var exceptionHandlingMiddleware = new ExceptionHandlingMiddleware(mockNextMiddleware, _log.Object);

            //act
            await exceptionHandlingMiddleware.InvokeAsync(httpContext);

            //assert
            Assert.Equal(HttpStatusCode.NotFound, (HttpStatusCode)httpContext.Response.StatusCode);
        }
    }
}
