using Autofac;
using BankApp.Application.Interfaces;
using BankApp.Application.Services;

namespace BankApp.Api.DI
{
    public static class ApplicationRegistrationHelper
    {
        public static void Register(ContainerBuilder builder)
        {
            builder.RegisterType<UserAppService>().As<IUserAppService>().InstancePerLifetimeScope();
            builder.RegisterType<TransactionAppService>().As<ITransactionAppService>().InstancePerLifetimeScope();
            builder.RegisterType<AccountAppService>().As<IAccountAppService>().InstancePerLifetimeScope();
        }
    }
}
