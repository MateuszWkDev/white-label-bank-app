using Autofac;
using Mainframe.Data.DbServices;
using Mainframe.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Mainframe.Data
{
    public static class MainframeDataDI
    {
        private const string DatabaseName = "Main";

        public static void RegisterDependecies(ContainerBuilder builder)
        {
            using (var dbContext = new MainframeContext(new DbContextOptionsBuilder<MainframeContext>()
                    .UseInMemoryDatabase(DatabaseName)
                    .Options))
            {
                dbContext.SeedData();
            }

            builder.Register(context => new MainframeContext(new DbContextOptionsBuilder<MainframeContext>()
                    .UseInMemoryDatabase(DatabaseName)
                    .Options)).InstancePerLifetimeScope();
            builder.RegisterType<UserDbService>().As<IUserDbService>().InstancePerLifetimeScope();
            builder.RegisterType<AccountDbService>().As<IAccountDbService>().InstancePerLifetimeScope();
            builder.RegisterType<TransactionDbService>().As<ITransactionDbService>().InstancePerLifetimeScope();
        }
    }
}
