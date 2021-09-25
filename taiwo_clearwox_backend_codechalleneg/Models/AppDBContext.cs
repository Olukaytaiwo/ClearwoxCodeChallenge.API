using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace taiwo_clearwox_backend_codechalleneg.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options)
          : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, DepartmentName = "IT" });

            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 2, DepartmentName = "HR" });
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 3, DepartmentName = "Payrol" });
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 4, DepartmentName = "Admin" });

            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 5, DepartmentName = "Sales" });

            // Seed Emoloyee Table
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 1,
                FirstName = "John",
                LastName = "Peter",
                MiddleName = "Paul",
                Email = "David@Pragimtech.com",
                DateofBirth = new DateTime(1980, 10, 5),
                Gender = Gender.Male,
                DepartmentId = 2,
                PhotoPath = "images/john.jpg"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 2,
                FirstName = "Sam",
                LastName = "Smith",
                MiddleName = "Rojan",
                Email = "Smith@Pragimtech.com",
                DateofBirth = new DateTime(1980, 10, 5),
                Gender = Gender.Male,
                DepartmentId = 2,
                PhotoPath = "images/john.jpg"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 3,
                FirstName = "Petreli",
                LastName = "Snow",
                MiddleName = "Raul",
                Email = "Raul@Pragimtech.com",
                DateofBirth = new DateTime(1980, 10, 5),
                Gender = Gender.Male,
                DepartmentId = 3,
                PhotoPath = "images/juli.jpg"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 4,
                FirstName = "Sunia",
                LastName = "Gupta",
                MiddleName = "Sukitra",
                Email = "Sukitra@Pragimtech.com",
                DateofBirth = new DateTime(1980, 10, 5),
                Gender = Gender.Female,
                DepartmentId = 4,
                PhotoPath = "images/juli.jpg"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 5 ,
                FirstName = "John",
                LastName = "Snow",
                MiddleName = "Ravenal",
                Email = "Ravenal@Pragimtech.com",
                DateofBirth = new DateTime(1980, 10, 5),
                Gender = Gender.Male,
                DepartmentId = 5,
                PhotoPath = "images/tetri.png"
            });


          





        }
    }
}
