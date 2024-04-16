using Autofac;
using Sobis.DAL.Abstract.AppUser;
using Sobis.DAL.Abstract.Category;
using Sobis.DAL.Abstract.Parameter;
using Sobis.DAL.Abstract.Product;
using Sobis.DAL.Concrete.EntityFramework.Repositories.AppUser;
using Sobis.DAL.Concrete.EntityFramework.Repositories.Category;
using Sobis.DAL.Concrete.EntityFramework.Repositories.Parameter;
using Sobis.DAL.Concrete.EntityFramework.Repositories.Product;

namespace Sobis.BLL.DependencyResolvers.Autofac
{
    public static class DbModuleHelpers
    {
        public static void RegisterDbModule(this ContainerBuilder builder)
        {
            builder.RegisterType<EfAppUserRepository>().As<IAppUserRepository>().SingleInstance();

            builder.RegisterType<EfParameterRepository>().As<IParameterRepository>().SingleInstance();
            builder.RegisterType<EfParameterDetailRepository>().As<IParameterDetailRepository>().SingleInstance();
            builder.RegisterType<EfParameterRepository>().As<IParameterRepository>().SingleInstance();
            builder.RegisterType<EfProductRepository>().As<IProductRepository>().SingleInstance();
            builder.RegisterType<EfCategoryRepository>().As<ICategoryRepository>().SingleInstance();
            builder.RegisterType<EfSubCategoryRepository>().As<ISubCategoryRepository>().SingleInstance();
        }
    }
}