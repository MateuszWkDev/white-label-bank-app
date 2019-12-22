using Autofac;
using Mainframe.Data.DbServices;
using Mainframe.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Mainframe.Data
{
    public static class MainframeDataDI
    {
        public static void RegisterDependecies(ContainerBuilder builder)
        {
            var dbContext = new MainframeContext(new DbContextOptionsBuilder<MainframeContext>()
                    .UseInMemoryDatabase(databaseName: "Main")
                    .Options
            );
            dbContext.SeedData();
            dbContext.SaveChanges();
            builder.RegisterInstance(dbContext).As<MainframeContext>().SingleInstance();
            builder.RegisterType<UserDbService>().As<IUserDbService>();
        }

    }
}
