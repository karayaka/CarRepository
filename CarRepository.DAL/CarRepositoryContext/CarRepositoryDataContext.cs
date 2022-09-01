using System;
using CarRepository.Domain.Models.EntityModels.VehicleModels;
using Microsoft.EntityFrameworkCore;

namespace CarRepository.DAL.CarRepositoryContext
{
    public class CarRepositoryDataContext: DbContext
    {
        public CarRepositoryDataContext(DbContextOptions<CarRepositoryDataContext> options):base(options)
        {
        }
        

        public DbSet<Bus> Buses { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Boat> Boats { get; set; }
    }
}

