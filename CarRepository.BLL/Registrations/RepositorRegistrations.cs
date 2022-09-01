using System;
using CarRepository.BLL.Interfaces;
using CarRepository.BLL.Repositorys;
using Microsoft.Extensions.DependencyInjection;

namespace CarRepository.BLL.Registrations
{
    public static class RepositorRegistrations
    {
        public static void AddRepository(this IServiceCollection services)
        {
            //There was a naming conflict.
            services.AddScoped<ICarRepository,Repositorys.CarRepository>();
            services.AddScoped<IBoatRepository, BoatRepository>();
            services.AddScoped<IBusRepository, BusRepository>();
        }
    }
}

