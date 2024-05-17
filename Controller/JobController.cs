using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobsOpeningsProject.Entities.JobEntities;
using JobsOpeningsProject.Repository.Contract;
using JobsOpeningsProject.Service.Contract;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace JobsOpeningsProject.Controller
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobController(IJobService JobService)
        {
            _jobService = JobService;
        }

        /// <Summary>
        /// Adds a new Job Entry; returns 201 with location header
        /// </Summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<CreatedResult> InsertJobEntry(JobRequest request)
        {
            var response = await _jobService.InsertJobEntry(request);
            return Created(new Uri(Request.GetEncodedUrl() + "/" + response), null);
        }

        /// <Summary>
        /// Updates an existing Job Entry
        /// </Summary>
        [HttpPut("UpdateJobEntry/{id:min(1)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<OkObjectResult> UpdateJobEntry(int id, JobRequest request)
        {
            var response = await _jobService.UpdateJobEntry(id, request);
            return Ok( new {message = "200 OK"});
        }

        /// <Summary>
        /// Lists all the existing job entries in the database
        /// </Summary>
        [HttpPost("ListAllJobs")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ObjectResult> ListAllJobs(JobListRequest request)
        {
            var response = await _jobService.ListAllJobs(request);
            return new ObjectResult(response);
        }

        /// <Summary>
        /// returns details for a single job entry
        /// </Summary>
        [HttpGet("GetJobDetails/{id:min(1)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ObjectResult> GetJobDetails(int id)
        {
            var response = await _jobService.GetJobDetails(id);
            return new ObjectResult(response);
        }
    }
}