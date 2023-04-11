using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarRepository.BLL.Interfaces;
using CarRepository.Domain.Models.DTO.BaseModels;
using CarRepository.Domain.Models.DTO.BoatModels;
using CarRepository.Domain.Models.EntityModels.VehicleModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRepository.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class BoatController : Controller
    {
        private readonly IBoatRepository boatRepository;

        private readonly IMapper mapper;

        public BoatController(IBoatRepository _boatRepository,IMapper _mapper)
        {
            boatRepository = _boatRepository;
            mapper = _mapper;
        }
        // GET: api/boat
        //test
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var model = boatRepository.GetNonDeleted<Boat>(t => true).Select(s => mapper.Map<BoatModel>(s));

                return Ok(new ResultModel<List<BoatModel>>(_Data: model.ToList(), _Lenght: model.Count()));
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong");
            }

        }

        // GET api/boat/id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var model = await boatRepository.GetByID<Boat>(id);
                var result = mapper.Map<BoatModel>(model);
                return Ok(new ResultModel<BoatModel>(_Data: result));
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong");
            }
        }

        // POST api/boat
        [HttpPost]
        public async Task<IActionResult> Post([FromForm]BoatModel model)
        {
            try
            {
                var result = mapper.Map<Boat>(model);
                await boatRepository.AddVehicle(result);
                await boatRepository.SaveChange();
                return Ok(new ResultModel<Boat>(_Data: result));
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong");
            }
        }

        // PUT api/boat
        [HttpPut]
        public async Task<IActionResult> Put([FromForm]BoatModel model)
        {
            try
            {
                var result = await boatRepository.GetByID<Boat>(model.ID);
                mapper.Map(model, result);
                boatRepository.Update(result);
                await boatRepository.SaveChange();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong");
            }
        }

        // DELETE api/boat/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await boatRepository.Delete<Boat>(id);
                await boatRepository.SaveChange();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong");
            }
        }
        // GET api/boat/getByColor/color
        [HttpGet("getByColor/{color}")]
        public async Task<IActionResult> getByColor(string color)
        {
            try
            {
                var boat = await boatRepository.GetVehicleByColor<Boat>(color);
                var result = mapper.Map<BoatModel>(boat);
                return Ok(new ResultModel<BoatModel>(_Data: result));
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong");
            }
        }
    }
}

