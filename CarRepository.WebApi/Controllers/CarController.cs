using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarRepository.BLL.Interfaces;
using CarRepository.Domain.Models.DTO.BaseModels;
using CarRepository.Domain.Models.DTO.CarModels;
using CarRepository.Domain.Models.EntityModels.VehicleModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRepository.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CarController : BaseController
    {
        private readonly ICarRepository carRepository;

        private readonly IMapper mapper;

        public CarController(ICarRepository _carRepository,IMapper _mapper)
        {
            carRepository = _carRepository;//this is against pascal casing standard but i don't like underscore in code
            mapper = _mapper;
        }
        // GET: Car/
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var models = carRepository.GetAllCars();
                return base.Ok(new ResultModel<List<CarModel>>(_Data:models.ToList(), _Lenght:models.Count()));
            }
            catch (Exception ex)
            {
                return ErrorHadling(ex);
            }
            
        }

        // GET api/car/id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var model = await carRepository.GetCarByID(id);
                return Ok(new ResultModel<CarModel>(_Data: model));
            }
            catch (Exception ex)
            {
                return ErrorHadling(ex);
            }
        }

        // POST api/car
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CarModel model)
        {
            try
            {
                var result = mapper.Map<Car>(model);
                await carRepository.AddVehicle(result);
                await carRepository.SaveChange();
                return Ok(new ResultModel<Car>(_Data: result));
            }
            catch (Exception ex)
            {
                return ErrorHadling(ex);
            }
        }

        // PUT api/car
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]CarModel model)
        {
            try
            {
                var result = await carRepository.GetByID<Car>(model.ID);
                mapper.Map(model,result);
                carRepository.UpdateVehicle(result);
                await carRepository.SaveChange();
                return Ok();
            }
            catch (Exception ex)
            {
                return ErrorHadling(ex);
            }
        }

        // DELETE api/car/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await carRepository.Delete<Car>(id);
                await carRepository.SaveChange();
                return Ok();
            }
            catch (Exception ex)
            {
                return ErrorHadling(ex);
            }
        }
        [HttpGet("getByColor/{color}")]
        public async Task<IActionResult> getByColor(string color)
        {
            try
            {
                var car = await carRepository.GetVehicleByColor<Car>(color);
                var result = mapper.Map<CarModel>(car);
                return Ok(new ResultModel<CarModel>(_Data: result));
            }
            catch (Exception ex)
            {
                return ErrorHadling(ex);
            }
        }
        [HttpPost("ToggleCarHeadlights/{ID}")]
        public async Task<IActionResult> ToggleCarHeadlights(int ID)
        {
            try
            {
                var car = await carRepository.ToggleCarHeadlights(ID);
                var result = mapper.Map<CarModel>(car);
                return Ok(new ResultModel<CarModel>(_Data: result));
            }
            catch (Exception ex)
            {
                return ErrorHadling(ex);
            }
        }
    }
}

