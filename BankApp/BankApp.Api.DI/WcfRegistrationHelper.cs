using System;
using System.ServiceModel;
using AccountService;
using Autofac;
using BankApp.WcfClient;
using Microsoft.Extensions.Configuration;
using TransactionService;
using UserService;

namespace BankApp.Api.DI
{
    public static class WcfRegistrationHelper
    {
        public static void Register(ContainerBuilder builder, IConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentException($"Argument is null: {nameof(configuration)}");
            }

            var baseUrl = configuration["BaseWcfClientUrl"];
            RegisterSingleClient<IUserService>(builder, baseUrl, "UserService.svc");
            RegisterSingleClient<IAccountService>(builder, baseUrl, "AccountService.svc");
            RegisterSingleClient<ITransactionService>(builder, baseUrl, "TransactionService.svc");
        }

        private static void RegisterSingleClient<TClient>(ContainerBuilder builder, string baseUrl, string serviceName)
        {
            builder
              .Register(c => new ChannelFactory<TClient>(
              new BasicHttpBinding(),
              new EndpointAddress($"{baseUrl}/{serviceName}")))
              .SingleInstance();
            builder
             .Register(c => c.Resolve<ChannelFactory<TClient>>().CreateChannel())
             .As<TClient>()
             .InstancePerLifetimeScope()
             .UseWcfSafeRelease();
        }
    }
}
