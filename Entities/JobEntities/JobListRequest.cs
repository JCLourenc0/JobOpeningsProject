using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsOpeningsProject.Entities.JobEntities
{
    public class JobListRequest
    {
        public string? Q { get; set; }
        public int PageNo { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int LocationId { get; set; }
        public int DepartmentId { get; set; }
    }
}