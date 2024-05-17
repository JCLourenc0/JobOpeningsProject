using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobsOpeningsProject.Entities.DepartmentEntities;
using JobsOpeningsProject.Repository.Contract;
using JobsOpeningsProject.Service.Contract;
using Microsoft.AspNetCore.Mvc;

namespace JobsOpeningsProject.Controller
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService DepartmentService)
        {
            _departmentService = DepartmentService;
        }


        /// <Summary>
        /// Returns a list of all department entries present in the database
        /// </Summary>
        [HttpGet("GetAllDepartments")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ObjectResult> GetAllDepartments()
        {
            var responses = await _departmentService.GetAllDepartments();
            return new ObjectResult(responses);
        }

        /// <Summary>
        /// Inserts a new department entry based on parameters entered
        /// </Summary>
        [HttpPost("InsertDepartment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ObjectResult> InsertDepartment(DepartmentRequest request)
        {
            var response = await _departmentService.InsertDepartment(request);
            return new ObjectResult(response);
        }

        /// <Summary>
        /// Updates exisitng department entries
        /// </Summary>
        [HttpPut("UpdateDepartment/{id:min(1)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ObjectResult> UpdateDepartment(int id, DepartmentRequest request)
        {
            var response = await _departmentService.UpdateDepartment(id, request);
            return new ObjectResult(response);
        }
    }
}