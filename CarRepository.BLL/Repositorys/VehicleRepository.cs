using System;
using CarRepository.BLL.Interfaces;
using CarRepository.DAL.CarRepositoryContext;
using CarRepository.Domain.Models.EntityModels.VehicleModels;

namespace CarRepository.BLL.Repositorys
{
    public class VehicleRepository:Repository ,IVehicleRepository
    {
        private readonly CarRepositoryDataContext context;
        public VehicleRepository(CarRepositoryDataContext _context):base(_context)
        {
            context = _context;
        }

        public async Task<T> AddVehicle<T>(T model) where T : BaseVehicle
        {
            try
            {
                model.ProductionDate = DateTime.Now;
                return await Add(model);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> GetVehicleByColor<T>(string color) where T : BaseVehicle
        {
            try
            {
                var model= await FindNonDeleted<T>(t => t.Color == color);
                if (model == null)
                    throw new Exception("vehicle not found");
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        

    }
}

