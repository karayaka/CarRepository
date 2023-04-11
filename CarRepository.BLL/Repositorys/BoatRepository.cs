using System;
using AutoMapper;
using CarRepository.BLL.Interfaces;
using CarRepository.DAL.CarRepositoryContext;
using CarRepository.Domain.Exceptions;
using CarRepository.Domain.Models.DTO.BoatModels;
using CarRepository.Domain.Models.EntityModels.VehicleModels;

namespace CarRepository.BLL.Repositorys
{
    public class BoatRepository:VehicleRepository,IBoatRepository
    {
        private readonly CarRepositoryDataContext context;
        private readonly IMapper mapper;

        public BoatRepository(CarRepositoryDataContext _context, IMapper _mapper) :base(_context)
        {
            context = _context;
            mapper = _mapper;
        }

        public IQueryable<BoatModel> GetAllBoad()
        {
            try
            {
                return GetNonDeleted<Boat>(t => true).Select(s => mapper.Map<BoatModel>(s));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BoatModel> GetBoadByID(int ID)
        {
            try
            {
                var model = await GetByID<Boat>(ID);
                if (model == null)
                    throw new NotFoundException();
                return mapper.Map<BoatModel>(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

