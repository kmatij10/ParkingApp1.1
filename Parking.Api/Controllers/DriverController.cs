using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Parking.Core.Repositories.Drivers;
using Parking.Data.Entities;

namespace Parking.Api.Controllers
{
    [ApiController]
    [Route("api/drivers")]
    public class DriverController : BaseController
    {
        private readonly IDriverRepository driverRepository;
        private readonly IMapper mapper;

        public DriverController(
            IDriverRepository driverRepository,
            IMapper mapper
        )
        {
            this.driverRepository = driverRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Driver>> GetAll([FromQuery] string search)
        {
            var driver = this.driverRepository.GetAll(search);
            return Ok(driver);
        }

        [HttpGet("{id}")]
        public ActionResult<Driver> GetOne(long id)
        {
            var entity = this.driverRepository.GetOne(id);
            var driver = this.mapper.Map<Driver>(entity);
            return Ok(driver);
        }
        [HttpPost]
        public ActionResult<Driver> Create(Driver c)
        {
            var driver = this.mapper.Map<Driver>(c);
            driver = this.driverRepository.Create(driver);
            return this.mapper.Map<Driver>(driver);
        }

        [HttpPut("{id}")]
        public ActionResult<Driver> Put(long id, Driver c)
        {
            var driver = this.driverRepository.Update(id, c);
            return Ok(driver);
        }
        [HttpDelete("{id}")]
        public ActionResult<Driver> Delete(long id)
        {
            this.driverRepository.Delete(id);
            return Ok();
        }
    }
}