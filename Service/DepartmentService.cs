using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobsOpeningsProject.Entities.DepartmentEntities;
using JobsOpeningsProject.Repository.Contract;
using JobsOpeningsProject.Service.Contract;

namespace JobsOpeningsProject.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository DepartmentRepository)
        {
            _departmentRepository = DepartmentRepository;
        }

        public async Task<IEnumerable<DepartmentEntity>> GetAllDepartments()
        {
            var response = await _departmentRepository.GetAllDepartments();
            return response;
        }

        public async Task<DepartmentEntity> InsertDepartment(DepartmentRequest request)
        {
            var response = await _departmentRepository.InsertDepartment(request);

            return response;
        }

        public async Task<DepartmentEntity> UpdateDepartment(int id, DepartmentRequest request)
        {
            var response = await _departmentRepository.UpdateDepartment(id, request);

            return response;
        }
    }
}