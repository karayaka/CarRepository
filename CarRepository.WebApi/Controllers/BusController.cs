using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarRepository.BLL.Interfaces;
using CarRepository.Domain.Models.DTO.BaseModels;
using CarRepository.Domain.Models.DTO.BusModels;
using CarRepository.Domain.Models.EntityModels.VehicleModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRepository.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class BusController : Controller
    {

        private readonly IBusRepository busRepository;

        private readonly IMapper mapper;

        public BusController(IBusRepository _busRepository,IMapper _mapper)
        {
            busRepository = _busRepository;
            mapper = _mapper;
        }

        // GET: api/bus
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var model = busRepository.GetNonDeleted<Bus>(t => true).Select(s => mapper.Map<BusModel>(s));

                return Ok(new ResultModel<List<BusModel>>(_Data: model.ToList(), _Lenght: model.Count()));
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong");
            }

        }

        // GET api/bus/id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var model = await busRepository.GetByID<Bus>(id);
                var result = mapper.Map<BusModel>(model);
                return Ok(new ResultModel<BusModel>(_Data: result));
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong");
            }
        }

        // POST api/bus
        [HttpPost]
        public async Task<IActionResult> Post([FromForm]BusModel model)
        {
            try
            {
                var result = mapper.Map<Bus>(model);
                await busRepository.AddVehicle(result);
                await busRepository.SaveChange();
                return Ok(new ResultModel<Bus>(_Data: result));
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong");
            }
        }

        // PUT api/bus
        [HttpPut]
        public async Task<IActionResult> Put([FromForm]BusModel model)
        {
            try
            {
                var result = await busRepository.GetByID<Bus>(model.ID);
                mapper.Map(model, result);
                busRepository.Update(result);
                await busRepository.SaveChange();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong");
            }
        }

        // DELETE api/bus/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await busRepository.Delete<Bus>(id);
                await busRepository.SaveChange();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong");
            }
        }
        // GET api/bus/getByColor/color
        [HttpGet("getByColor/{color}")]
        public async Task<IActionResult> getByColor(string color)
        {
            try
            {
                var bus = await busRepository.GetVehicleByColor<Bus>(color);
                var result = mapper.Map<BusModel>(bus);
                return Ok(new ResultModel<BusModel>(_Data: result));
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong");
            }
        }
    }
}

