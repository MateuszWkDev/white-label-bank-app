using Autofac;
using Autofac.Integration.Wcf;
using Mainframe.Data;
using MainServices.Services;
using System;
using System.Web;

namespace MainServices
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
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