using API.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Models
{
    public class EntityDBContext : DbContext
    {

        public EntityDBContext(DbContextOptions<EntityDBContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var Id = Guid.NewGuid();
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id=Id, Name = "First Employee", Salary = 1000, Email = "Employee@gmail.com", Mobile = 123456789 });

            modelBuilder.Entity<EmployeeTax>().HasData(
                new EmployeeTax { Id = Guid.NewGuid(), EmployeeId = Id, Tax = 10, NetSalary = 900 });
        }



        public DbSet<Employee> Employee { get; set; }
        public DbSet<EmployeeTax> EmployeeTax { get; set; }


    }
}
