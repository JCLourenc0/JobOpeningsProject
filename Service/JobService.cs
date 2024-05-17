using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobsOpeningsProject.Entities.JobEntities;
using JobsOpeningsProject.Repository.Contract;
using JobsOpeningsProject.Service.Contract;

namespace JobsOpeningsProject.Service
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;

        public JobService(IJobRepository JobRepository)
        {
            _jobRepository = JobRepository;
        }

        public async Task<JobDetailResponse?> GetJobDetails(int id)
        {
            var response = await _jobRepository.GetJobDetails(id);
            return response;
        }

        public async Task<int> InsertJobEntry(JobRequest request)
        {
            var response = await _jobRepository.InsertJobEntry(request);
            return response;
        }

        public async Task<JobListRsponse> ListAllJobs(JobListRequest request)
        {
            var response = await _jobRepository.ListAllJobs(request);
            return response;
        }

        public async Task<bool> UpdateJobEntry(int id, JobRequest request)
        {
            var response = await _jobRepository.UpdateJobEntry(id, request);
            return response;
        }
    }
}