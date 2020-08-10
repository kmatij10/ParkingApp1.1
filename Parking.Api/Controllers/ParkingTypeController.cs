using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Parking.Core.Repositories;
using Parking.Data.Entities;

namespace Parking.Api.Controllers
{
    [ApiController]
    [Route("api/parkingtypes")]
    public class ParkingTypeController : BaseController
    {
        private readonly IParkingTypeRepository parkingTypeRepository;
        private readonly IMapper mapper;

        public ParkingTypeController(
            IParkingTypeRepository parkingTypeRepository,
            IMapper mapper
        )
        {
            this.parkingTypeRepository = parkingTypeRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ParkingType>> GetAll([FromQuery] string search)
        {
            var parkingType = this.parkingTypeRepository.GetAll(search);
            return Ok(parkingType);
        }

        [HttpGet("{id}")]
        public ActionResult<ParkingType> GetOne(long id)
        {
            var entity = this.parkingTypeRepository.GetOne(id);
            var parkingType = this.mapper.Map<ParkingType>(entity);
            return Ok(parkingType);
        }

        [HttpPost]
        public ActionResult<ParkingType> Create(ParkingType c)
        {
            var parkingType = this.mapper.Map<ParkingType>(c);
            parkingType = this.parkingTypeRepository.Create(parkingType);
            return this.mapper.Map<ParkingType>(parkingType);
        }

        [HttpPatch("{id}")]
        public ActionResult<ParkingType> Patch(int id, [FromBody]JsonPatchDocument<ParkingType> doc)
        {
            var parkingType = this.parkingTypeRepository.GetOne(id);
            this.parkingTypeRepository.Patch(id, doc);
            return Ok(parkingType);
        }
        [HttpDelete("{id}")]
        public ActionResult<ParkingType> Delete(long id)
        {
            this.parkingTypeRepository.Delete(id);
            return Ok();
        }
    }
}