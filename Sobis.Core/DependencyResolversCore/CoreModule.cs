using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Sobis.Core.CrossCunttingConcerns.Caching;
using Sobis.Core.CrossCunttingConcerns.Caching.Microsoft;
using Sobis.Core.Logging;
using Sobis.Core.Utilities.IoC;
using System.Diagnostics;

namespace Sobis.Core.DependencyResolversCore
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection collection)
        {
            collection.AddMemoryCache();
            collection.AddScoped<IHttpContextAccessor, HttpContextAccessor>();
            collection.AddSingleton<ILoggerService, NLogLoggerManager>();
            collection.AddSingleton<ICacheService, MemoryCacheManager>();
            collection.AddSingleton<Stopwatch>();
        }
    }
}
