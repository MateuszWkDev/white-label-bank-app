namespace Mainframe.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using Mainframe.Data.Models;
    using Microsoft.EntityFrameworkCore;

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
            Users.AddRange(
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
                });
            Users.ToList().ForEach(user => user.Accounts.ToList().AddRange(new List<Account>
                    {
                        new Account()
                        {
                            Name = "Main",
                            Number = "707342708484",
                            Balance = 100000,
                        },
                        new Account()
                        {
                            Name = "General Savings",
                            Number = "998416035273",
                            Balance = 10000,
                        },
                        new Account()
                        {
                            Name = "Savings For Holiday",
                            Number = "408723509807",
                            Balance = 5000,
                        },
                    }));
        }
    }
}
