using System;
using AutoMapper;
using CarRepository.BLL.Interfaces;
using CarRepository.DAL.CarRepositoryContext;
using CarRepository.Domain.Exceptions;
using CarRepository.Domain.Models.DTO.BusModels;
using CarRepository.Domain.Models.EntityModels.VehicleModels;

namespace CarRepository.BLL.Repositorys
{
    public class BusRepository:VehicleRepository,IBusRepository
    {
        private readonly IMapper mapper;

        public BusRepository(CarRepositoryDataContext _context, IMapper _mapper) :base(_context)
        {
            mapper = _mapper;
        }

        public IQueryable<BusModel> GetAllBus()
        {
            try
            {
                return GetNonDeleted<Bus>(t => true).Select(s => mapper.Map<BusModel>(s));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BusModel> GetBusByID(int ID)
        {
            try
            {
                var model = await GetByID<Bus>(ID);
                if (model == null)
                    throw new NotFoundException();
                return mapper.Map<BusModel>(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

