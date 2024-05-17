using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobsOpeningsProject.Entities.LocationEntities;
using JobsOpeningsProject.Models;
using JobsOpeningsProject.Repository.Contract;
using Microsoft.EntityFrameworkCore;

namespace JobsOpeningsProject.Repository
{
    public class LocationRepository : ILocationRepository
    {
        private readonly JobsOpeningsDbContext _context;

        public LocationRepository(JobsOpeningsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LocationEntity>> GetAllLocations()
        {
            return await _context.Locations.AsNoTracking().Select(l => new LocationEntity
            {
                Id = l.Locationid,
                Title = l.Locationtitle,
                State = l.Locationstate,
                City = l.Locationcity,
                Country = l.Locationcountry,
                Zip = l.Locationzip
            }).OrderBy(a => a.City).ToListAsync();
        }

        public async Task<IEnumerable<LocationEntity>> InsertLocation(LocationRequest request)
        {
            var newLocation = new Location
            {
                Locationtitle = request.LocationTitle ?? "",
                Locationcity = request.LocationCity ?? "",
                Locationstate = request.LocationState ?? "",
                Locationcountry = request.LocationCountry ?? "",
                Locationzip = request.LocationZip
            };
            await _context.Locations.AddAsync(newLocation);
            await _context.SaveChangesAsync();

            var locationEntity = new LocationEntity
            {
                Id = newLocation.Locationid,
                Title = newLocation.Locationtitle,
                State = newLocation.Locationstate,
                City = newLocation.Locationcity,
                Country = newLocation.Locationcountry,
                Zip = newLocation.Locationzip
            };

            return new List<LocationEntity> { locationEntity };
        }

        public async Task<LocationEntity> UpdateLocation(int id, LocationRequest request)
        {
            LocationEntity locationEntity = new LocationEntity();
            var locationRecord = await _context.Locations.AsNoTracking().FirstOrDefaultAsync(x => x.Locationid == id);
            if (locationRecord != null && request != null)
            {
                locationRecord.Locationtitle = request != null && request.LocationTitle != null ? request.LocationTitle : "";
                locationRecord.Locationcity = request != null && request.LocationCity != null ? request.LocationCity : "";
                locationRecord.Locationstate = request != null && request.LocationState != null ? request.LocationState : "";
                locationRecord.Locationcountry = request != null && request.LocationCountry != null ? request.LocationCountry : "";
                locationRecord.Locationzip = request != null && request.LocationZip > 0 ? request.LocationZip : 222222;

                _context.Locations.Update(locationRecord);
                _context.SaveChanges();
            }

            if (locationRecord != null)
            {
                locationEntity = new LocationEntity
                {
                    Id = id,
                    Title = locationRecord.Locationtitle,
                    State = locationRecord.Locationstate,
                    City = locationRecord.Locationcity,
                    Country = locationRecord.Locationcountry,
                    Zip = locationRecord.Locationzip
                };
            }
            return locationEntity;
        }
    }
}