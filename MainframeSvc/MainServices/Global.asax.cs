namespace MainServices
{
    using System;
    using System.Web;
    using Autofac;
    using Autofac.Integration.Wcf;
    using Mainframe.Data;
    using MainServices.Services;

#pragma warning disable CA1716 // Identifiers should not match keywords
    public class Global : HttpApplication
#pragma warning restore CA1716 // Identifiers should not match keywords
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores
        protected void Application_Start(object sender, EventArgs e)
#pragma warning restore CA1707 // Identifiers should not contain underscores
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<UserService>()
                .As<IUserService>();
            builder.RegisterType<AccountService>()
                .As<IAccountService>();
            builder.RegisterType<TransactionService>()
                .As<ITransactionService>();
            MainframeDataDI.RegisterDependecies(builder);
            var container = builder.Build();
            AutofacHostFactory.Container = container;
        }
    }
}