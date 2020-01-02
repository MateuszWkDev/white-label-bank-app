namespace Mainframe.Data
{
    using Autofac;
    using Mainframe.Data.DbServices;
    using Mainframe.Data.Interfaces;
    using Microsoft.EntityFrameworkCore;

    public static class MainframeDataDI
    {
        public static void RegisterDependecies(ContainerBuilder builder)
        {
#pragma warning disable CA2000 // We are using this as single instance with in memory db
            var dbContext = new MainframeContext(new DbContextOptionsBuilder<MainframeContext>()
                    .UseInMemoryDatabase(databaseName: "Main")
                    .Options);
#pragma warning restore CA2000 // Dispose objects before losing scope
            dbContext.SeedData();
            dbContext.SaveChanges();
            builder.RegisterInstance(dbContext).As<MainframeContext>().SingleInstance();
            builder.RegisterType<UserDbService>().As<IUserDbService>();
            builder.RegisterType<AccountDbService>().As<IAccountDbService>();
            builder.RegisterType<TransactionDbService>().As<ITransactionDbService>();
        }
    }
}
