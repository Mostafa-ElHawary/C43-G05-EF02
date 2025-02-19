using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using C43_G05_EF02.Entities;

namespace C43_G05_EF02.Configurations
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(50);
            builder.Property(e => e.DateOfBirth).IsRequired();
            builder.Property(e => e.Email).IsRequired().HasMaxLength(100);
            builder.Property(e => e.PhoneNumber).HasMaxLength(15);
            builder.Property(e => e.Address).HasMaxLength(200);
            builder.Property(e => e.Position).HasMaxLength(50);
            builder.Property(e => e.Salary).HasColumnType("decimal(18,2)");
            builder.Property(e => e.DateOfJoining).IsRequired();

            // Configure one-to-one relationship
            builder.HasOne(e => e.Manager)
                .WithOne(d => d.Manager)
                .HasForeignKey<Employee>(e => e.Id);
        }
    }
}
