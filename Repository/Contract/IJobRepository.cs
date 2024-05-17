using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobsOpeningsProject.Entities.JobEntities;

namespace JobsOpeningsProject.Repository.Contract
{
    public interface IJobRepository
    {
        Task<JobDetailResponse?> GetJobDetails(int id);
        Task<int> InsertJobEntry(JobRequest request);
        Task<JobListRsponse> ListAllJobs(JobListRequest request);
        Task<bool> UpdateJobEntry(int id, JobRequest request);
    }
}