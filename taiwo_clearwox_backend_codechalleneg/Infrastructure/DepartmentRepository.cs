using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Department>> GetDepartments()
        {
            var result = await appDbContext.Departments.ToListAsync();
            return result;
            //return await appDbContext.Departments;
        }

        public async Task<Department> GetDepartment(int departmentId)
        {
            var results = appDbContext.Departments.
                FirstOrDefault(d => d.Id == departmentId);
            return results;
        }

    
    }
}
