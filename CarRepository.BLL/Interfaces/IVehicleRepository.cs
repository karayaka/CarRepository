using System;
using CarRepository.Domain.Models.EntityModels.VehicleModels;

namespace CarRepository.BLL.Interfaces
{
    public interface IVehicleRepository:IRepository
    {
        /// <summary>
        /// Get Vehicle By Vehicle Color
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="color"></param>
        /// <returns></returns>
        Task<T> GetVehicleByColor<T>(string color) where T : BaseVehicle;
        /// <summary>
        /// Add Vehicle 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<T> AddVehicle<T>(T model) where T : BaseVehicle;
    }
}

