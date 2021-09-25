using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using taiwo_clearwox_backend_codechalleneg.Interfaces;
using taiwo_clearwox_backend_codechalleneg.Models;

namespace taiwo_clearwox_backend_codechalleneg.Infrastructure
{
    public class DepartmentRepository : IDepartmentRepository
    {

        private readonly AppDBContext appDbContext;
        public DepartmentRepository(AppDBContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<Department> GetDepartments()
        {
            return appDbContext.Departments;
        }

        public Department GetDepartment(int departmentId)
        {
            var results = appDbContext.Departments.
                FirstOrDefault(d => d.DepartmentId == departmentId);
            return results;
        }

    
    }
}
