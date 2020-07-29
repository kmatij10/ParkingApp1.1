using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Parking.Core.Repositories.Rates;
using Parking.Data.Entities;

namespace Parking.Api.Controllers
{
    [ApiController]
    [Route("api/rates")]
    public class RateController : BaseController
    {
        private readonly IRateRepository rateRepository;
        private readonly IMapper mapper;

        public RateController(
            IRateRepository rateRepository,
            IMapper mapper
        )
        {
            this.rateRepository = rateRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Rate>> GetAll([FromQuery] string search)
        {
            var rate = this.rateRepository.GetAll(search);
            return Ok(rate);
        }

        [HttpGet("{id}")]
        public ActionResult<Rate> GetOne(long id)
        {
            var entity = this.rateRepository.GetOne(id);
            var rate = this.mapper.Map<Rate>(entity);
            return Ok(rate);
        }

        [HttpPost]
        public ActionResult<Rate> Create(Rate c)
        {
            var rate = this.mapper.Map<Rate>(c);
            rate = this.rateRepository.Create(rate);
            return this.mapper.Map<Rate>(rate);
        }

        [HttpPut("{id}")]
        public ActionResult<Rate> Put(long id, Rate c)
        {
            var rate = this.rateRepository.Update(id, c);
            return Ok(rate);
        }
        [HttpDelete("{id}")]
        public ActionResult<Rate> Delete(long id)
        {
            this.rateRepository.Delete(id);
            return Ok();
        }
    }
}