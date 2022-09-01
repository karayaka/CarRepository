using System;
using CarRepository.BLL.Interfaces;
using CarRepository.DAL.CarRepositoryContext;
using CarRepository.Domain.Models.EntityModels.VehicleModels;

namespace CarRepository.BLL.Repositorys
{
    public class CarRepository :VehicleRepository,ICarRepository
    {
        private readonly CarRepositoryDataContext context;

        public CarRepository(CarRepositoryDataContext _context) : base(_context)
        {
            context = _context;

        }

        public async Task<Car> ToggleCarHeadlights(int ID)
        {
            try
            {
                var car = await GetByID<Car>(ID);
                if (car == null)
                    throw new Exception("Car Not Found");
                car.IsOpenHeadlights = !car.IsOpenHeadlights;                
                Update(car);

                await SaveChange();
                return car;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}

