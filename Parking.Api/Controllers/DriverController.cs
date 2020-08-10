using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Parking.Core.Repositories;
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

        [HttpPatch("{id}")]
        public ActionResult<Driver> Patch(int id, [FromBody]JsonPatchDocument<Driver> doc)
        {
            var driver = this.driverRepository.GetOne(id);
            this.driverRepository.Patch(id, doc);
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