using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using School.DataAccess;
using School.DataAccess.UnitOfWorks;
using School.Services;
using School.WebApi.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.WebApi
{
    public static class ServiceCollectionExtension
    {
        public static void AddDbContext (this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<SchoolDBContext>(options =>
              options.UseSqlServer(connectionString));
        }

        public static void AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork>(unitOfWork => new UnitOfWork(unitOfWork.GetRequiredService<SchoolDBContext>()));
            services.AddScoped<UnitOfWorkFilterAttribute>();
        }

        public static void AddQueryProcessors(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
        }

    }
}
