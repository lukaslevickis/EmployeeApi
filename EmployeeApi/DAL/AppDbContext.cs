using System;
using EmployeeApi.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.DAL
{
    public class AppDbContext: DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companies { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .HasMany(c => c.Employees)
                .WithOne(e => e.Company);
        }
    }
}
