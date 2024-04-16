using Microsoft.AspNetCore.Http;
using Sobis.Core.Logging;
using Sobis.Core.Utilities.Results.Concrete;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sobis.Core.Middlewares
{
    public class ExceptionHandlerMiddleWare
    {
        private readonly ILoggerService loggerService;
        private readonly RequestDelegate request;
        public ExceptionHandlerMiddleWare(RequestDelegate request, ILoggerService loggerService)
        {
            this.request = request;
            this.loggerService = loggerService;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await request(httpContext);
            }
            catch (System.Exception e)
            {
                loggerService.LogError(e);
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                httpContext.Response.ContentType = "application/json";

                var result = new ErrorResult(e.Message + e.InnerException);

                string json = JsonSerializer.Serialize(result);
                await httpContext.Response.WriteAsync(json);
            }
        }
    }
}
