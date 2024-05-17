using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobsOpeningsProject.Entities.LocationEntities;
using JobsOpeningsProject.Repository.Contract;
using JobsOpeningsProject.Service.Contract;

namespace JobsOpeningsProject.Service
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;

        public LocationService(ILocationRepository LocationRepository)
        {
            _locationRepository = LocationRepository;
        }

        public async Task<IEnumerable<LocationEntity>> GetAllLocations()
        {
            var response = await _locationRepository.GetAllLocations();
            return response;
        }

        public async Task<IEnumerable<LocationEntity>> InsertLocation(LocationRequest request)
        {
            var response = await _locationRepository.InsertLocation(request);
            return response;
        }

        public async Task<LocationEntity> UpdateLocation(int id, LocationRequest request)
        {
            var response = await _locationRepository.UpdateLocation(id, request);
            return response;
        }

    }
}