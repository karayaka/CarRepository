using System;
namespace CarRepository.Domain.Models.EntityModels.VehicleModels
{
    public class Car:BaseVehicle
    {
        public string Wheels { get; set; }

        public bool IsOpenHeadlights { get; set; }
    }
}

