using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Parking.Core.Repositories;
using Parking.Data.Entities;

namespace Parking.Api.Controllers
{
    [ApiController]
    [Route("api/parkingspaces")]
    public class ParkingSpaceController : BaseController
    {
        private readonly IParkingSpaceRepository parkingSpaceRepository;
        private readonly IMapper mapper;

        public ParkingSpaceController(
            IParkingSpaceRepository parkingSpaceRepository,
            IMapper mapper
        )
        {
            this.parkingSpaceRepository = parkingSpaceRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ParkingSpace>> GetAll([FromQuery] string search)
        {
            var parkingSpace = this.parkingSpaceRepository.GetAll(search);
            return Ok(parkingSpace);
        }

        [HttpGet("{id}")]
        public ActionResult<ParkingSpace> GetOne(long id)
        {
            var entity = this.parkingSpaceRepository.GetOne(id);
            var parkingSpace = this.mapper.Map<ParkingSpace>(entity);
            return Ok(parkingSpace);
        }

        [HttpPost]
        public ActionResult<ParkingSpace> Create(ParkingSpace c)
        {
            var parkingSpace = this.mapper.Map<ParkingSpace>(c);
            parkingSpace = this.parkingSpaceRepository.Create(parkingSpace);
            return this.mapper.Map<ParkingSpace>(parkingSpace);
        }

        [HttpPatch("{id}")]
        public ActionResult<ParkingSpace> Patch(int id, [FromBody]JsonPatchDocument<ParkingSpace> doc)
        {
            var parkingSpace = this.parkingSpaceRepository.GetOne(id);
            this.parkingSpaceRepository.Patch(id, doc);
            return Ok(parkingSpace);
        }
        [HttpDelete("{id}")]
        public ActionResult<ParkingSpace> Delete(long id)
        {
            this.parkingSpaceRepository.Delete(id);
            return Ok();
        }
    }
}