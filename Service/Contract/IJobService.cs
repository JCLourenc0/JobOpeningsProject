using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobsOpeningsProject.Entities.JobEntities;

namespace JobsOpeningsProject.Service.Contract
{
    public interface IJobService
    {
        Task<JobDetailResponse?> GetJobDetails(int id);
        Task<int> InsertJobEntry(JobRequest request);
        Task<JobListRsponse> ListAllJobs(JobListRequest request);
        Task<bool> UpdateJobEntry(int id, JobRequest request);
    }
}