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
            modelBuilder.Entity<Expense>()
                .HasOne(x => x.User)
                .WithMany(x => x.Expenses)
                .HasForeignKey(x => x.UserId);
                
            modelBuilder.SeedData();
        }

        public DbSet<User> Users { get; set; }
    }
}
