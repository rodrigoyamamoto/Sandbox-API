using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Sandbox.Business.Models;

namespace Sandbox.Data.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            FeedInMemoryDatabaseWithUsers();
        }

        private void FeedInMemoryDatabaseWithUsers()
        {
            for (var i = 1; i <= 25; i++)
            {
                var user = new User
                {
                    Name = $"User {i}",
                    Email = $"user{i}@gmail.com"
                };

                Users.Add(user);
                SaveChanges();
            }

        }

        public List<User> GetUsers()
        {
            return Users.Local.ToList<User>();
        }

    }
}