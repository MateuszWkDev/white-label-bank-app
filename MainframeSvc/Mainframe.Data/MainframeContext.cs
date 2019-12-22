using Mainframe.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mainframe.Data
{
    public class MainframeContext : DbContext
    {
        public MainframeContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public void SeedData()
        {
            Users.AddRange(
                new User { Id = 1, Login = "testUser1", Name = " John Test1", Password = "test1password" },
                new User { Id = 2, Login = "testUser2", Name = " John Test2", Password = "test2password" },
                new User { Id = 3, Login = "testUser3", Name = " John Test3", Password = "test3password" }
                );
        }
    }
}
