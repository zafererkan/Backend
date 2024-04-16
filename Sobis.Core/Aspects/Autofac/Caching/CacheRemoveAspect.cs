using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using Sobis.Core.CrossCunttingConcerns.Caching;
using Sobis.Core.Utilities.Interceptors;
using Sobis.Core.Utilities.IoC;

namespace Sobis.Core.Aspects.Autofac.Caching
{
    public class CacheRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICacheService _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheService>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
