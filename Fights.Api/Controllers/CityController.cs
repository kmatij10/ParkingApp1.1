using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Fights.Core.Repositories.Cities;
using Fights.Core.Repositories.Protests;
using Fights.Data.Entities;
using Fights.Data.Models;

namespace Fights.Api.Controllers
{
    [Route("api/cities")]
    public class CityController : BaseController
    {

        private readonly ICityRepository cityRepository;
        private readonly IMapper mapper;

        public CityController(
            ICityRepository cityRepository,
            IMapper mapper
        )
        {
            this.cityRepository = cityRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<City>> GetAll([FromQuery] string search)
        {
            var cities = this.cityRepository.GetAll(search);
            return Ok(cities);
        }

        // [HttpGet("{id}")]
        // public ActionResult<ProtestDetail> GetOne(long id)
        // {
        //     var entity = this.cityRepository.GetOne(id);
        //     var protest = this.mapper.Map<ProtestDetail>(entity);
        //     return Ok(protest);
        // }

        // [HttpPut("{id}")]
        // public ActionResult<Protest> Put(long id, Protest p)
        // {
        //     var protest = this.cityRepository.Update(id, p);
        //     return Ok(protest);
        // }

        // [HttpDelete("{id}")]
        // public ActionResult<Protest> Delete(long id)
        // {
        //     this.cityRepository.Delete(id);
        //     return Ok();
        // }


    }
}
