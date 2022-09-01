using System;
using CarRepository.Domain.Models.EntityModels.BaseEntitiys;

namespace CarRepository.Domain.Models.EntityModels.VehicleModels
{
    public class BaseVehicle:BaseEntitiy
    {
        public string Color { get; set; }

        public string Brand { get; set; }

        public DateTime ProductionDate { get; set; }

    }
}

