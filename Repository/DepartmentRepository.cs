using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobsOpeningsProject.Entities.DepartmentEntities;
using JobsOpeningsProject.Models;
using JobsOpeningsProject.Repository.Contract;
using Microsoft.EntityFrameworkCore;

namespace JobsOpeningsProject.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly JobsOpeningsDbContext _context;

        public DepartmentRepository(JobsOpeningsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DepartmentEntity>> GetAllDepartments()
        {
            return await _context.Departments.AsNoTracking().Select(d => new DepartmentEntity
            {
                Id = d.Departmentid,
                Title = d.Departmenttitle
            }).OrderBy(a => a.Title).ToListAsync();

        }

        public async Task<DepartmentEntity> InsertDepartment(DepartmentRequest request)
        {
            var newDepartment = new Department
            {
                Departmenttitle = request.DepartmentTitle ?? ""
            };
            await _context.Departments.AddAsync(newDepartment);
            await _context.SaveChangesAsync();

            var departmentEntity = new DepartmentEntity
            {
                Id = newDepartment.Departmentid,
                Title = newDepartment.Departmenttitle.Trim()
            };

            return departmentEntity;
        }

        public async Task<DepartmentEntity> UpdateDepartment(int id, DepartmentRequest request)
        {
            DepartmentEntity departmentEntity = new DepartmentEntity();
            var departmentDetails = await _context.Departments.AsNoTracking().FirstOrDefaultAsync(x => x.Departmentid == id);
            if (departmentDetails != null && request != null)
            {
                departmentDetails.Departmenttitle = request != null && request.DepartmentTitle != null ? request.DepartmentTitle : "";
                _context.Departments.Update(departmentDetails);
                _context.SaveChanges();

                if (departmentDetails != null)
                {
                    departmentEntity = new DepartmentEntity
                    {
                        Id = id,
                        Title = departmentDetails.Departmenttitle
                    };
                }
            }
            return departmentEntity;
        }
    }
}