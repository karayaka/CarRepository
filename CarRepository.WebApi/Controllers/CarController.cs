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
    public class CarController : Controller
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
                var model = carRepository.GetNonDeleted<Car>(t => true).Select(s => mapper.Map<CarModel>(s));

                return Ok(new ResultModel<List<CarModel>>(_Data: model.ToList(), _Lenght: model.Count()));
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong");
            }
            
        }

        // GET api/car/id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var model = await carRepository.GetByID<Car>(id);
                var result = mapper.Map<CarModel>(model);
                return Ok(new ResultModel<CarModel>(_Data:result));
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong");
            }
        }

        // POST api/car
        [HttpPost]
        public async Task<IActionResult> Post([FromForm]CarModel model)
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
                return BadRequest("Something went wrong");
            }
        }

        // PUT api/car
        [HttpPut]
        public async Task<IActionResult> Put([FromForm]CarModel model)
        {
            try
            {
                var result = await carRepository.GetByID<Car>(model.ID);
                mapper.Map(model,result);
                carRepository.Update(result);
                await carRepository.SaveChange();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong");
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
                return BadRequest("Something went wrong");
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
                return BadRequest("Something went wrong");
            }
        }
        [HttpPost("ToggleCarHeadlights")]
        public async Task<IActionResult> ToggleCarHeadlights([FromForm]int ID)
        {
            try
            {
                var car = await carRepository.ToggleCarHeadlights(ID);
                var result = mapper.Map<CarModel>(car);
                return Ok(new ResultModel<CarModel>(_Data: result));
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong");
            }
        }
    }
}

