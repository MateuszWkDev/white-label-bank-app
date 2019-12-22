using Mainframe.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mainframe.Data
{
    public class MainframeContext : DbContext
    {
        public static readonly MainframeContext Instance = new MainframeContext(new DbContextOptionsBuilder<MainframeContext>()
                .UseInMemoryDatabase(databaseName: "Main")
                .Options
        );
        public MainframeContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
