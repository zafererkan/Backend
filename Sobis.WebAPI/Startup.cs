using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Sobis.Common.MappingProfile.AutoMapper.Profiles.AppUser;
using Sobis.Core.DependencyResolversCore;
using Sobis.Core.Extensions;
using Sobis.Core.Middlewares;
using Sobis.Core.Securitiy;
using Sobis.Core.Securitiy.JWT;
using Sobis.Core.Utilities.IoC;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Sobis.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); ;
            //services.AddAutoMapper(typeof(AppUserProfile));
            services.AddAutoMapper(typeof(Startup).GetTypeInfo().Assembly,
                                   typeof(AppUserProfile).GetTypeInfo().Assembly
);
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin();
                        builder.AllowAnyHeader();
                        builder.AllowAnyMethod();
                    });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sobis.WebAPI", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
            var tokenOptions = Configuration.GetSection("SbsTokenOptions").Get<TokenOptions>();
            //var dbOptions = Configuration.GetSection("SbsTokenOptions").Get<DbOptions>();

            TokenOptionsStatic.Issuer = tokenOptions.Issuer;
            TokenOptionsStatic.Audience = tokenOptions.Audience;
            TokenOptionsStatic.AccessTokenExpiration = tokenOptions.AccessTokenExpiration;
            TokenOptionsStatic.SecurityKey = tokenOptions.SecurityKey;

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
                });
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));


            services.AddDependencyResolvers(new ICoreModule[]
            {
                new CoreModule(),
            });
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sobis.WebAPI v1"));
            }
            app.UseMiddleware<ExceptionHandlerMiddleWare>();
            app.UseMiddleware<RequestResponseMiddleWare>();
            app.UseHttpsRedirection();
            //app.UseDeveloperExceptionPage();
            app.UseCors("AllowAllOrigins");
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
