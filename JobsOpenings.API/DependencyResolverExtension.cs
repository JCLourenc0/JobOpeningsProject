using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobsOpeningsProject.Repository;
using JobsOpeningsProject.Repository.Contract;
using JobsOpeningsProject.Service;
using JobsOpeningsProject.Service.Contract;

namespace JobsOpeningsProject.JobsOpenings.API
{
    public static class DependencyResolverExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentService, DepartmentService>()
            .AddScoped<IJobService, JobService>()
            .AddScoped<ILocationService, LocationService>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection repositories)
        {
            repositories.AddScoped<IDepartmentRepository, DepartmentRepository>()
            .AddScoped<IJobRepository, JobRepository>()
            .AddScoped<ILocationRepository, LocationRepository>();

            return repositories;
        }
    }
}