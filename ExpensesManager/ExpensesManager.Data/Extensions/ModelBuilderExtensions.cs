using ExpensesManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesManager.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = 1,
                    Email = "johndoe@test.com",
                    FirstName = "John",
                    LastName = "Doe",
                    DateOfBirth = new DateTime(2000, 01, 01).ToUniversalTime()
                },
                new User()
                {
                    Id = 2,
                    Email = "johnsmith@test.com",
                    FirstName = "John",
                    LastName = "Smith",
                    DateOfBirth = new DateTime(2002, 01, 01).ToUniversalTime()
                }
            );
        }
    }
}
