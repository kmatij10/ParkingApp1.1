using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Parking.Data.Entities;
using Parking.Core.Repositories;
using Microsoft.AspNetCore.JsonPatch;

namespace Parking.Api.Controllers
{
    [ApiController]
    [Route("api/cars")]
    public class CarController : BaseController
    {
        private readonly ICarRepository carRepository;
        private readonly IMapper mapper;

        public CarController(
            ICarRepository carRepository,
            IMapper mapper
        )
        {
            this.carRepository = carRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Car>> GetAll([FromQuery] string search)
        {
            var car = this.carRepository.GetAll(search);
            return Ok(car);
        }

        [HttpGet("{id}")]
        public ActionResult<Car> GetOne(long id)
        {
            var entity = this.carRepository.GetOne(id);
            var car = this.mapper.Map<Car>(entity);
            return Ok(car);
        }

        [HttpPost]
        public ActionResult<Car> Create(Car c)
        {
            var car = this.mapper.Map<Car>(c);
            car = this.carRepository.Create(car);
            return this.mapper.Map<Car>(car);
        }
        
        [HttpPatch("{id}")]
        public ActionResult<Car> Patch(int id, [FromBody]JsonPatchDocument<Car> doc)
        {
            var car = this.carRepository.GetOne(id);
            this.carRepository.Patch(id, doc);
            return Ok(car);
        }

        [HttpDelete("{id}")]
        public ActionResult<Car> Delete(long id)
        {
            this.carRepository.Delete(id);
            return Ok();
        }
    }
}