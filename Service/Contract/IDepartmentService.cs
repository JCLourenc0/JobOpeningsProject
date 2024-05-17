using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobsOpeningsProject.Entities.DepartmentEntities;

namespace JobsOpeningsProject.Service.Contract
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentEntity>> GetAllDepartments();
        Task<DepartmentEntity> InsertDepartment(DepartmentRequest request);
        Task<DepartmentEntity> UpdateDepartment(int id, DepartmentRequest request);
    }
}