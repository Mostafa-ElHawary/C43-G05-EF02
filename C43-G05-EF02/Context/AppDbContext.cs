using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C43_G05_EF02.Entities;
using Microsoft.EntityFrameworkCore;
using C43_G05_EF02.Configurations;

namespace C43_G05_EF02.Context
{
    internal class AppDbContext : DbContext
    {
        // OnConfiguring is a function to open conection with database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = .; Database = EF02; Trusted_Connection = True; TrustServerCertificate = True");
        }

        public DbSet<Employee> Employees { get; set; }
         
         // Assignment
         // 2.Create Relations Between Tables ( Use Previous Assignment )
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());

            // Configure one-to-one relationship
            modelBuilder.Entity<Department>()
                .HasOne(d => d.Manager)
                .WithOne(e => e.Manager)
                .HasForeignKey<Employee>(e => e.Id);
        }
    }
}
