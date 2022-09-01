using System;
namespace CarRepository.Domain.Models.DTO.CarModels
{
    public class CarModel
    {
        public int ID { get; set; }

        public string Wheels { get; set; }

        public bool IsOpenHeadlights { get; set; }

        public string Color { get; set; }

        public string Brand { get; set; }

    }
}

