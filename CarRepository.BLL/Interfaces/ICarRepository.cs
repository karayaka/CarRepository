using System;
using CarRepository.Domain.Models.DTO.CarModels;
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
        Task<CarModel> ToggleCarHeadlights(int ID);
        /// <summary>
        /// get All Cars
        /// </summary>
        /// <returns></returns>
        IQueryable<CarModel> GetAllCars();
        /// <summary>
        /// Get Car By ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        Task<CarModel> GetCarByID(int ID);
    }
}

