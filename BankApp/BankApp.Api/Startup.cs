using System.ServiceModel;
using Autofac;
using BankApp.WcfClient;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using UserService;

namespace BankApp.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Bank API", Version = "v1" });
            });
            services.AddControllers();
        }

        public static void ConfigureContainer(ContainerBuilder builder)
        {
            builder
            .Register(c => new ChannelFactory<IUserService>(
    new BasicHttpBinding(),
    new EndpointAddress("http://localhost:61700/Services/UserService.svc")))
  .SingleInstance();

            // Register the service interface using a lambda that creates
            // a channel from the factory. Include the UseWcfSafeRelease()
            // helper to handle proper disposal.
            builder
              .Register(c => c.Resolve<ChannelFactory<IUserService>>().CreateChannel())
              .As<IUserService>()
              .InstancePerLifetimeScope()
              .UseWcfSafeRelease();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bank API V1");
            });
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
