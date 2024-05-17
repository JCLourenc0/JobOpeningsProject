using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobsOpeningsProject.Entities.DepartmentEntities;
using JobsOpeningsProject.Entities.LocationEntities;

namespace JobsOpeningsProject.Entities.JobEntities
{
    public class JobDetailResponse
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string? Title { get; set; }
        public string? Description { get; set; }
        public LocationEntity? Location { get; set; }
        public DepartmentEntity? Department { get; set; }
        public DateTime? PostedDate { get; set; }
        public DateTime? ClosingDate { get; set; }
    }
}