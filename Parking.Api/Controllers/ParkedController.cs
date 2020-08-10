using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Parking.Core.Repositories;
using Parking.Data.Entities;

namespace Parking.Api.Controllers
{
    [ApiController]
    [Route("api/parked")]
    public class ParkedController : BaseController
    {
        private readonly IParkedRepository parkedRepository;
        private readonly IMapper mapper;

        public ParkedController(
            IParkedRepository parkedRepository,
            IMapper mapper
        )
        {
            this.parkedRepository = parkedRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Parked>> GetAll([FromQuery] string search)
        {
            var parked = this.parkedRepository.GetAll(search);
            return Ok(parked);
        }

        [HttpGet("{id}")]
        public ActionResult<Parked> GetOne(long id)
        {
            var entity = this.parkedRepository.GetOne(id);
            var parked = this.mapper.Map<Parked>(entity);
            return Ok(parked);
        }
        [HttpPost]
        public ActionResult<Parked> Create(Parked c)
        {
            var parked = this.mapper.Map<Parked>(c);
            parked = this.parkedRepository.Create(parked);
            return this.mapper.Map<Parked>(parked);
        }

        [HttpPatch("{id}")]
        public ActionResult<Parked> Patch(int id, [FromBody]JsonPatchDocument<Parked> doc)
        {
            var parked = this.parkedRepository.GetOne(id);
            this.parkedRepository.Patch(id, doc);
            return Ok(parked);
        }
        [HttpDelete("{id}")]
        public ActionResult<Parked> Delete(long id)
        {
            this.parkedRepository.Delete(id);
            return Ok();
        }
    }
}