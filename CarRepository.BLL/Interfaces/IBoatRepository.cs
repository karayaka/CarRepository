using System;
using CarRepository.Domain.Models.DTO.BoatModels;

namespace CarRepository.BLL.Interfaces
{
    /// <summary>
    /// Boat-specific methods should be written
    /// </summary>
    public interface IBoatRepository:IVehicleRepository
    {
        /// <summary>
        /// get all boads
        /// </summary>
        /// <returns></returns>
        IQueryable<BoatModel> GetAllBoad();
        /// <summary>
        /// get boad by ıd
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        Task<BoatModel> GetBoadByID(int ID);
    }
}

