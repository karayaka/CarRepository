using System;
using CarRepository.Domain.Models.DTO.BusModels;

namespace CarRepository.BLL.Interfaces
{
    /// <summary>
    /// Bus-specific methods should be written
    /// </summary>
    public interface IBusRepository:IVehicleRepository
    {
        /// <summary>
        /// Get All Buss
        /// </summary>
        /// <returns></returns>
        IQueryable<BusModel> GetAllBus();
        /// <summary>
        /// Get bus by id
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        Task<BusModel> GetBusByID(int ID);
    }
}

