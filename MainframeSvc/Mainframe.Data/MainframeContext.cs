using System.Collections.Generic;
using System.Linq;
using Mainframe.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Mainframe.Data
{
    public class MainframeContext : DbContext
    {
        public MainframeContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public void SeedData()
        {
            var users = new List<User>
            {
                new User
                {
                    Id = 1,
                    Login = "test1User",
                    Name = "John Test1",
                    Password = "test1Password",
                },
                new User
                {
                    Id = 2,
                    Login = "test2User",
                    Name = "John Test2",
                    Password = "test2Password",
                },
                new User
                {
                    Id = 3,
                    Login = "test3User",
                    Name = "John Test3",
                    Password = "test3Password",
                },
            };
            users.ForEach(user =>
            {
                user.Accounts.Add(new Account()
                {
                    Name = "Main",
                    Number = "707342708484",
                    Balance = 100000,
                });
                user.Accounts.Add(new Account()
                {
                    Name = "General Savings",
                    Number = "998416035273",
                    Balance = 10000,
                });
                user.Accounts.Add(new Account()
                {
                    Name = "Savings For Holiday",
                    Number = "408723509807",
                    Balance = 5000,
                });
            });
            Users.AddRange(users);
            SaveChanges();
        }
    }
}
