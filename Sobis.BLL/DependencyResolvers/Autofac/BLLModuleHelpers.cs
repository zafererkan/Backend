using Autofac;
using Sobis.Core.Securitiy.JWT;
using Sobis.DAL.Abstract.AppUser;
using Sobis.DAL.Concrete.EntityFramework.Repositories.AppUser;

namespace Sobis.BLL.DependencyResolvers.Autofac
{
    public static class BLLModuleHelpers
    {
        public static void RegisterBllModule(this ContainerBuilder builder)
        {
            builder.RegisterType<EfAppUserRepository>().As<IAppUserRepository>().SingleInstance();
        }
    }
}