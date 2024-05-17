using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobsOpeningsProject.Entities.LocationEntities;

namespace JobsOpeningsProject.Repository.Contract
{
    public interface ILocationRepository
    {
        Task<IEnumerable<LocationEntity>> GetAllLocations();
        Task<IEnumerable<LocationEntity>> InsertLocation(LocationRequest request);
        Task<LocationEntity> UpdateLocation(int id, LocationRequest request);
    }
}