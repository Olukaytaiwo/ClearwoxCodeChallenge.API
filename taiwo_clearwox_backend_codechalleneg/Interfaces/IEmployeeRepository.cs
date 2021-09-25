using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using taiwo_clearwox_backend_codechalleneg.Models;

namespace taiwo_clearwox_backend_codechalleneg.Interfaces
{
    public interface IEmployeeRepository
    {

        Task<IEnumerable<Employee>> Search( string name, Gender? gender);
        Task <IEnumerable<Employee>> GetEmployees();
        Task <Employee> GetEmployee(int employeeId);
        Task<Employee> GetEmployeeByEmail(string email);
        Task <Employee> AddEmployee(Employee employeeId);
        Task <Employee> UpdateEmployee(Employee employeeId);
        Task <Employee> DeleteEmployee (int employeeId);


    }
}
