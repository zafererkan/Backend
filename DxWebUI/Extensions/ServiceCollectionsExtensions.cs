using AutoMapper;
using DxWebUI.ApiConsumer.Abstract;
using DxWebUI.ApiConsumer.Concrete;
using DxWebUI.Utilities;
using Radzen;
using Sobis.Common.MappingProfile.AutoMapper.Profiles.AppUser;

namespace DxWebUI.DependencyResolvers
{
    public static class ServiceCollectionsExtensions
    {


        public static IServiceCollection LoadService(this IServiceCollection service)
        {
            service.AddRadzenComponents();
            service.AddScoped<AppState>();
            service.AddScoped<IParameterDetailConsumerService, ParameterDetailConsumerManager>();
            service.AddScoped<IAppUserConsumerService, AppUserConsumerManager>();
            service.AddScoped<IAuthConsumerService, AuthConsumerManager>();



            //service.AddScoped<AuthenticationStateProvider, AuthStateProvider>();

            //service.AddScoped<NotificationService>();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(typeof(AppUserProfile));
            });

            IMapper mapper = mapperConfig.CreateMapper();
            service.AddSingleton(mapper);

            return service;
        }
    }
}
