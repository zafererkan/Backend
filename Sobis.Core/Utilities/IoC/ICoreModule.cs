using Microsoft.Extensions.DependencyInjection;

namespace Sobis.Core.Utilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection collection);
    }
}
