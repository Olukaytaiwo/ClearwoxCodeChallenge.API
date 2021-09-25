using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using taiwo_clearwox_backend_codechalleneg.Interfaces;
using taiwo_clearwox_backend_codechalleneg.Models;

namespace taiwo_clearwox_backend_codechalleneg.Infrastructure
{
    public class EmployeeRepository : IEmployeeRepository     
    {

        private readonly AppDBContext appDbContext;

        public EmployeeRepository(AppDBContext appDbContext )
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var result = await appDbContext.Employees.ToListAsync();         
                return result;                     
        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
            var result = await appDbContext.Employees
               //.Include(e => e.DepartmentId)
               .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);

            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
           
        }

        public async Task<Employee> GetEmployeeByEmail(string email)
        {
            var result = await appDbContext.Employees              
               .FirstOrDefaultAsync(e => e.Email == email);
            return result;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            var result = await appDbContext.Employees.AddAsync(employee);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }


        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result = await appDbContext.Employees.
               FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);

            if (result != null)
            {
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.MiddleName = employee.MiddleName;
                result.Gender = employee.Gender;
                result.Email = employee.Email;
                result.DateofBirth = employee.DateofBirth;
                result.DepartmentId = employee.DepartmentId;
                result.PhotoPath = employee.PhotoPath;

                await appDbContext.SaveChangesAsync();

                return result;
            }

            return null;

        }

        public async Task<Employee> DeleteEmployee(int employeeId)
        {
            var result = await appDbContext.Employees.
               FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
            if (result == null)
            {
                return null;
            }
            else
            {
                appDbContext.Employees.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
        }

        public async Task<IEnumerable<Employee>> Search(string name, Gender? gender)
        {
            IQueryable<Employee> query = appDbContext.Employees;
            if ( !string.IsNullOrEmpty(name) )
            {
                query = query.Where(e => e.FirstName.Contains(name)
                || e.LastName.Contains(name));
            }

            if (  gender != null)
            {
                query = query.Where(e => e.Gender == gender);
            }
            return await query.ToListAsync();

        }
    }
}
