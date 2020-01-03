using System;
using Autofac;
using Microsoft.Extensions.Configuration;

namespace BankApp.Api.DI
{
    public static class RegistrationHelper
    {
        public static void Register(ContainerBuilder builder, IConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentException($"Argument is null: {nameof(configuration)}");
            }

            WcfRegistrationHelper.Register(builder, configuration);
            ApplicationRegistrationHelper.Register(builder);
        }
    }
}
