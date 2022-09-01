using System;
using System.Configuration;
using System.Reflection;
using CarRepository.DAL.CarRepositoryContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CarRepository.DAL.Registrations
{
    public static class DalRegistration
    {
        public static void AddDataContext(this IServiceCollection services,string connectionString)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));

            services.AddDbContext<CarRepositoryDataContext>(o =>
            o.UseMySql(connectionString,serverVersion));

        }
        public static void AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}

