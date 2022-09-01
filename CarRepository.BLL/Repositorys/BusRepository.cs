using System;
using CarRepository.BLL.Interfaces;
using CarRepository.DAL.CarRepositoryContext;

namespace CarRepository.BLL.Repositorys
{
    public class BusRepository:VehicleRepository,IBusRepository
    {
        private readonly CarRepositoryDataContext context;

        public BusRepository(CarRepositoryDataContext _context):base(_context)
        {
        }
    }
}

