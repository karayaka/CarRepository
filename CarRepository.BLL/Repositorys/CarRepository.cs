using System;
using AutoMapper;
using CarRepository.BLL.Interfaces;
using CarRepository.DAL.CarRepositoryContext;
using CarRepository.Domain.Exceptions;
using CarRepository.Domain.Models.DTO.CarModels;
using CarRepository.Domain.Models.EntityModels.VehicleModels;

namespace CarRepository.BLL.Repositorys
{
    public class CarRepository :VehicleRepository,ICarRepository
    {
        private readonly CarRepositoryDataContext context;
        private readonly IMapper mapper;

        public CarRepository(CarRepositoryDataContext _context, IMapper _mapper) : base(_context)
        {
            context = _context;
            mapper = _mapper;
        }

        public IQueryable<CarModel> GetAllCars()
        {
            try
            {
                return GetNonDeleted<Car>(t => true).Select(s => mapper.Map<CarModel>(s));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CarModel> GetCarByID(int ID)
        {
            try
            {
                var model = await GetByID<Car>(ID);
                if (model == null)
                    throw new NotFoundException();
                return mapper.Map<CarModel>(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CarModel> ToggleCarHeadlights(int ID)
        {
            try
            {
                var car = await GetByID<Car>(ID);
                if (car == null)
                    throw new NotFoundException();
                car.IsOpenHeadlights = !car.IsOpenHeadlights;                
                Update(car);

                await SaveChange();
                return mapper.Map<CarModel>(car);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}

