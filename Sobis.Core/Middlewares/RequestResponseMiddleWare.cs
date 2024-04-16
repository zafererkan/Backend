using Microsoft.AspNetCore.Http;
using Sobis.Core.Logging;
using System.Threading.Tasks;

namespace Sobis.Core.Middlewares
{
    public class RequestResponseMiddleWare
    {
        private readonly RequestDelegate requestDelegate;
        private readonly ILoggerService loggerService;
        public RequestResponseMiddleWare(RequestDelegate requestDelegate, ILoggerService loggerService)
        {
            this.requestDelegate = requestDelegate;
            this.loggerService = loggerService;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            //request loginng
            loggerService.LogInfo($"Query String: {string.Join(',', httpContext.Request.QueryString)}");
            loggerService.LogInfo($"Query Keys: {string.Join(',', httpContext.Request.Query.Keys)}");
            //loggerService.LogInfo($"Query Form: {string.Join(',', httpContext.Request.Form)}");
            //loggerService.LogInfo($"Header: {httpContext.Request.Headers}");

            await requestDelegate.Invoke(httpContext);

            //Response Logging
            //string reader = await new StreamReader(httpContext.Request.Body, Encoding.UTF8).ReadToEndAsync();
            //loggerService.LogInfo($"Response: {reader}");
        }
    }
}
