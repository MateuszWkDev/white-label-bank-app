using Autofac;
using BankApp.Api.DI;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace BankApp.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Bank API", Version = "v1" });
                var securityScheme = new OpenApiSecurityScheme()
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert login and password",
                    Type = SecuritySchemeType.ApiKey,
                    Name = "Authorization",

                    // This should be used for proper basic authentication config but doesn't pass Authorization header in swagger UI
                    // Scheme = "Basic",
                    // Type = SecuritySchemeType.Http,
                };
                c.AddSecurityDefinition("BasicAuthentication", securityScheme);
                var securityReq = new OpenApiSecurityRequirement();
                c.OperationFilter<SecurityRequirementsOperationFilter>();
            });
            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
            services.AddCors();
            services.AddControllers();
            services.AddApplicationInsightsTelemetry();
        }

        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(options =>
            {
                options.WithOrigins("http://localhost:3000");
                options.AllowCredentials();
                options.AllowAnyHeader();
                options.AllowAnyMethod();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bank API V1");
            });
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            RegistrationHelper.Register(builder, Configuration);
        }
    }
}
