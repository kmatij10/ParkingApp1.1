using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Parking.Core.Repositories;
using Parking.Data.Entities;

namespace Parking.Api.Controllers
{
    [ApiController]
    [Route("api/availabilities")]
    public class AvailabilityController : BaseController
    {
        private readonly IAvailabilityRepository availabilityRepository;
        private readonly IMapper mapper;

        public AvailabilityController(
            IAvailabilityRepository availabilityRepository,
            IMapper mapper
        )
        {
            this.availabilityRepository = availabilityRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Availability>> GetAll([FromQuery] string search)
        {
            var availability = this.availabilityRepository.GetAll(search);
            return Ok(availability);
        }

        [HttpGet("{id}")]
        public ActionResult<Availability> GetOne(long id)
        {
            var entity = this.availabilityRepository.GetOne(id);
            var availability = this.mapper.Map<Availability>(entity);
            return Ok(availability);
        }

        [HttpPost]
        public ActionResult<Availability> Create(Availability c)
        {
            var availability = this.mapper.Map<Availability>(c);
            availability = this.availabilityRepository.Create(availability);
            return this.mapper.Map<Availability>(availability);
        }
        
        [HttpPatch("{id}")]
        public ActionResult<Availability> Patch(int id, [FromBody]JsonPatchDocument<Availability> doc)
        {
            var availability = this.availabilityRepository.GetOne(id);
            this.availabilityRepository.Patch(id, doc);
            return Ok(availability);
        }

        [HttpDelete("{id}")]
        public ActionResult<Availability> Delete(long id)
        {
            this.availabilityRepository.Delete(id);
            return Ok();
        }
    }
}