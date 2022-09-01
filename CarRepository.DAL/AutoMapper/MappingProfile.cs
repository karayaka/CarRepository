using System;
using AutoMapper;
using CarRepository.Domain.Models.DTO.BoatModels;
using CarRepository.Domain.Models.DTO.BusModels;
using CarRepository.Domain.Models.DTO.CarModels;
using CarRepository.Domain.Models.EntityModels.VehicleModels;

namespace CarRepository.DAL.AutoMapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Car,CarModel>().ReverseMap();

            CreateMap<Bus,BusModel>().ReverseMap();

            CreateMap<Boat,BoatModel>().ReverseMap();

        }
    }
}

