using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobsOpeningsProject.Entities.LocationEntities;
using JobsOpeningsProject.Repository.Contract;
using JobsOpeningsProject.Service.Contract;
using Microsoft.AspNetCore.Mvc;

namespace JobsOpeningsProject.Controller
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService LocationService)
        {
            _locationService = LocationService;
        }

        /// <Summary>
        /// Inserts a new location entry based on parameters entered
        /// </Summary>
        [HttpPost("InsertLocation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ObjectResult> InsertLocation(LocationRequest request)
        {
            var response = await _locationService.InsertLocation(request);
            return new ObjectResult(response);
        }

        /// <Summary>
        /// Updates exisitng location entries
        /// </Summary>
        [HttpPut("UpdateLocation/{id:min(1)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ObjectResult> UpdateLocation(int id, LocationRequest request)
        {
            var response = await _locationService.UpdateLocation(id, request);
            return new ObjectResult(response);
        }

        /// <Summary>
        /// Returns a list of all location entries present in the database
        /// </Summary>
        [HttpGet("GetAllLocations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ObjectResult> GetAllLocations()
        {
            var response = await _locationService.GetAllLocations();
            return new ObjectResult(response);
        }
    }
}