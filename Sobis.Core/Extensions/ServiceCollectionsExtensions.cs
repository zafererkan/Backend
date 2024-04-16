using Microsoft.Extensions.DependencyInjection;
using Sobis.Core.Utilities.IoC;

namespace Sobis.Core.Extensions
{
    public static class ServiceCollectionsExtensions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection ServiceCollection, ICoreModule[] CoreModules)
        {
            foreach (var module in CoreModules)
            {
                module.Load(ServiceCollection);
            }

            return ServiceTool.Create(ServiceCollection);
        }
    }
}
