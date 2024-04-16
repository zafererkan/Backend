using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Sobis.BLL.Abstract;
using Sobis.BLL.Abstract.AppUser;
using Sobis.BLL.Abstract.Category;
using Sobis.BLL.Abstract.Options;
using Sobis.BLL.Abstract.Parameter;
using Sobis.BLL.Concrete.AppUser;
using Sobis.BLL.Concrete.Category;
using Sobis.BLL.Concrete.Options;
using Sobis.BLL.Concrete.Parameter;
using Sobis.BLL.Concrete.Product;
using Sobis.Core.Logging;
using Sobis.Core.Securities;
using Sobis.Core.Securities.SbsSecurity;
using Sobis.Core.Securitiy.JWT;
using Sobis.Core.Utilities.Interceptors;

namespace Sobis.BLL.DependencyResolvers.Autofac
{
    public class AutofacBLLModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            AutofacBLLModuleHelpers.SetStaticSettings();

            builder.RegisterDbModule();

            builder.RegisterType<NLogLoggerManager>().As<ILoggerService>().SingleInstance();
            builder.RegisterType<SbsSecurityService>().As<ISecurityService>().SingleInstance();
            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();
            builder.RegisterType<AppUserManager>().As<IAppUserService>().SingleInstance();
            builder.RegisterType<OptionManager>().As<IOptionService>().SingleInstance();
            builder.RegisterType<ParameterManager>().As<IParameterService>().SingleInstance();
            builder.RegisterType<ParameterDetailManager>().As<IParameterDetailService>().SingleInstance();          
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();          
            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();          
            builder.RegisterType<SubCategoryManager>().As<ISubCategoryService>().SingleInstance();          


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
