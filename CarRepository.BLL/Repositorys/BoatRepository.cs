using System;
using CarRepository.BLL.Interfaces;
using CarRepository.DAL.CarRepositoryContext;

namespace CarRepository.BLL.Repositorys
{
    public class BoatRepository:VehicleRepository,IBoatRepository
    {
        private readonly CarRepositoryDataContext context;
        public BoatRepository(CarRepositoryDataContext _context):base(_context)
        {
            context = _context;
        }
    }
}

