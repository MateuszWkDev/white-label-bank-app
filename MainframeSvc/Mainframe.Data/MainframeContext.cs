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
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public void SeedData()
        {
            Users.AddRange(
                new User
                {
                    Id = 1,
                    Login = "testUser1",
                    Name = "John Test1",
                    Password = "test1password",
                    Accounts = new List<Account>
                    {
                        new Account()
                        {
                            Name = "Main",
                            Number= "326969508270",
                            Balance= 100000
                        },
                        new Account()
                        {
                            Name = "General Savings",
                            Number= "559057915531",
                            Balance= 10000
                        },
                        new Account()
                        {
                            Name = "Savings For Holiday",
                            Number= "649673171513",
                            Balance= 5000
                        }
                    }

                },
                new User
                {
                    Id = 2,
                    Login = "testUser2",
                    Name = "John Test2",
                    Password = "test2password",
                    Accounts = new List<Account>
                    {
                        new Account()
                        {
                            Name = "Main",
                            Number= "489939746573",
                            Balance= 100000
                        },
                        new Account()
                        {
                            Name = "General Savings",
                            Number= "841240720500",
                            Balance= 10000
                        },
                        new Account()
                        {
                            Name = "Savings For Holiday",
                            Number= "536999109546",
                            Balance= 5000
                        }
                    }
                },
                new User
                {
                    Id = 3,
                    Login = "testUser3",
                    Name = "John Test3",
                    Password = "test3password",
                    Accounts = new List<Account>
                    {
                        new Account()
                        {
                            Name = "Main",
                            Number= "707342708484",
                            Balance= 100000
                        },
                        new Account()
                        {
                            Name = "General Savings",
                            Number= "998416035273",
                            Balance= 10000
                        },
                        new Account()
                        {
                            Name = "Savings For Holiday",
                            Number= "408723509807",
                            Balance= 5000
                        }
                    }
                });
        }
    }
}
