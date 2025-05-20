using ExpensesManager.Data.Entities;
using ExpensesManager.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesManager.Data
{
    public class ExpensesManagerDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        // Needed for EF Core
        public ExpensesManagerDbContext() { }

        public ExpensesManagerDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("PostgresExpensesManagerDB"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expense>(x =>
            {
                x.HasOne(y => y.User)
                .WithMany(y => y.Expenses)
                .HasForeignKey(y => y.UserId);

                x.HasMany(y => y.Limits)
                .WithOne(y => y.Expense)
                .HasForeignKey(y => y.ExpenseId);
            });
                
            modelBuilder.SeedData();
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Expense> Expenses { get; set; }

        public DbSet<Limit> Limits { get; set; }
    }
}
