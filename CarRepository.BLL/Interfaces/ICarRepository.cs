using System;
using CarRepository.Domain.Models.EntityModels.VehicleModels;

namespace CarRepository.BLL.Interfaces
{
    public interface ICarRepository:IVehicleRepository
    {
        /// <summary>
        /// turn on/off headlights 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        Task<Car> ToggleCarHeadlights(int ID);
    }
}

