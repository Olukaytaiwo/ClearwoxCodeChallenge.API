﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using taiwo_clearwox_backend_codechalleneg.Models;

namespace taiwo_clearwox_backend_codechalleneg.Interfaces
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetDepartments();
        Department GetDepartment(int departmentId);
    }
}
