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
                new Department { Id = 1,  Name = "IT" , Address = "No 32, Bishop street Mowe, lagos"});

            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 2, Name = "HR", Address = "No 3, rasack Bishi street Ojudu Berger, lagos" });
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 3, Name = "Payrol", Address = "No 1, Muri okunola close, lagos" });
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 4, Name = "Admin", Address = "No 77, Tola Aboyade crecent Alagbado, lagos" });

            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 5, Name = "Sales", Address = "No 22, Marina, lagos" });

            // Seed Emoloyee Table
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 1,
                FirstName = "John",
                LastName = "Peter",
                MiddleName = "Paul",
                Email = "David@yahoo.com",
                DateofBirth = new DateTime(1980, 10, 5),
                Gender = Gender.Male,
                DepartmentId = 2,
                DepartmentName = "HR",
                PhotoPath = "images/john.jpg",
                 Address = "sort imagery close, obada lagos",
                  JobTitle = "HR assistant"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 2,
                FirstName = "Sam",
                LastName = "Smith",
                MiddleName = "Rojan",
                Email = "Smith@yahoo.com",
                DateofBirth = new DateTime(1980, 10, 5),
                Gender = Gender.Male,
                DepartmentId = 2,
                 DepartmentName = "HR",
                PhotoPath = "images/john.jpg",
                Address = "medical road ikeja lagos",
                JobTitle = "head HR"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 3,
                FirstName = "Petreli",
                LastName = "Snow",
                MiddleName = "Raul",
                Email = "Raul@yahoo.com",
                DateofBirth = new DateTime(1980, 10, 5),
                Gender = Gender.Male,
                DepartmentId = 3,
                 DepartmentName = "Payrol",
                PhotoPath = "images/juli.jpg",
                Address = "5, ibado road lekki lagos",
                JobTitle = "Accounting officer"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 4,
                FirstName = "Sunia",
                LastName = "Gupta",
                MiddleName = "Sukitra",
                Email = "Sukitra@yahoo.com",
                DateofBirth = new DateTime(1980, 10, 5),
                Gender = Gender.Female,
                DepartmentId = 4,
                DepartmentName = "Admin",
                PhotoPath = "images/juli.jpg",
                Address = "Titilope awofeso, Yaba lagos",
                JobTitle = "Head Adin"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 5 ,
                FirstName = "John",
                LastName = "Snow",
                MiddleName = "Ravenal",
                Email = "Ravenal@yahoo.com",
                DateofBirth = new DateTime(1980, 10, 5),
                Gender = Gender.Male,
                DepartmentId = 5,
                DepartmentName = "Sales",
                PhotoPath = "images/tetri.png",
                Address = "ketu alapere lagos",
                JobTitle = "Sales Executive"
            });


          





        }
    }
}
