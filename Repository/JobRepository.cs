using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobsOpeningsProject.Entities.DepartmentEntities;
using JobsOpeningsProject.Entities.JobEntities;
using JobsOpeningsProject.Entities.LocationEntities;
using JobsOpeningsProject.Models;
using JobsOpeningsProject.Repository.Contract;
using Microsoft.EntityFrameworkCore;

namespace JobsOpeningsProject.Repository
{
    public class JobRepository : IJobRepository
    {
        private readonly JobsOpeningsDbContext _context;

        public JobRepository(JobsOpeningsDbContext context)
        {
            _context = context;
        }

        public async Task<JobDetailResponse?> GetJobDetails(int id)
        {
            var response = new JobDetailResponse();
            response = await (
                from j in _context.Jobs.AsNoTracking()
                join l in _context.Locations.AsNoTracking() on j.Locationid equals l.Locationid
                join d in _context.Departments.AsNoTracking() on j.Departmentid equals d.Departmentid
                where j.Jobid == id
                select new JobDetailResponse
                {
                    Id = j.Jobid,
                    Code = j.Jobcode,
                    Title = j.Jobtitle,
                    Description = j.Jobdescription,
                    Location = new LocationEntity
                    {
                        Id = l.Locationid,
                        Title = l.Locationtitle,
                        City = l.Locationcity,
                        State = l.Locationstate,
                        Country = l.Locationcountry,
                        Zip = l.Locationzip
                    },
                    Department = new DepartmentEntity
                    {
                        Id = d.Departmentid,
                        Title = d.Departmenttitle
                    },
                    PostedDate = j.Posteddate,
                    ClosingDate = j.Closingdate
                }
            ).FirstOrDefaultAsync();
            if (response != null) { return response; }
            return null;
        }

        public async Task<int> InsertJobEntry(JobRequest request)
        {
            var newJobEntry = new Job
            {
                Jobtitle = request.JobTitle ?? "",
                Jobdescription = request.JobDescription ?? "",
                Locationid = request.LocationId,
                Departmentid = request.DepartmentId,
                Closingdate = request.ClosingDate,
                Posteddate = DateTime.Now
            };
            await _context.Jobs.AddAsync(newJobEntry);
            await _context.SaveChangesAsync();
            return newJobEntry.Jobid;
        }

        public async Task<JobListRsponse> ListAllJobs(JobListRequest request)
        {
            var jobDetails = from j in _context.Jobs.AsNoTracking()
                             select j;

            if (!string.IsNullOrEmpty(request.Q))
                jobDetails = jobDetails.Where(a => a.Jobtitle.ToLower().Contains(request.Q.ToLower()));

            if (request.DepartmentId > 0)
                jobDetails = jobDetails.Where(a => a.Departmentid == request.DepartmentId);

            if (request.LocationId > 0)
                jobDetails = jobDetails.Where(a => a.Locationid == request.LocationId);

            var count = jobDetails.Count();

            var results = from q in jobDetails
                          join l in _context.Locations on q.Locationid equals l.Locationid
                          join d in _context.Departments on q.Departmentid equals d.Departmentid
                          select new JobsEntity
                          {
                              Id = q.Jobid,
                              Code = q.Jobcode,
                              Title = q.Jobtitle,
                              Location = l.Locationtitle,
                              Department = d.Departmenttitle,
                              PostedDate = q.Posteddate,
                              ClosingDate = q.Closingdate
                          };

            var response = new JobListRsponse()
            {
                Total = count,
                Data = await results.Skip((request.PageNo - 1) * request.PageSize).Take(request.PageSize).ToListAsync()
            };
            return response;
        }

        public async Task<bool> UpdateJobEntry(int id, JobRequest request)
        {
            bool isUpdated = false;
            var JobRecord = await _context.Jobs.AsNoTracking().FirstOrDefaultAsync(x => x.Jobid == id);
            if (JobRecord != null && request != null)
            {
                JobRecord.Jobtitle = request != null && request.JobTitle != null ? request.JobTitle : "";
                JobRecord.Jobdescription = request != null && request.JobDescription != null ? request.JobDescription : "";
                JobRecord.Locationid = request.LocationId;
                JobRecord.Departmentid = request.DepartmentId;
                JobRecord.Closingdate = request.ClosingDate;
                _context.Jobs.Update(JobRecord);
                isUpdated = Convert.ToBoolean(_context.SaveChanges());
            }
            return isUpdated;
        }
    }
}