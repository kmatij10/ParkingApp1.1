using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Fights.Core.Repositories.Protests;
using Fights.Data.Entities;
using Fights.Data.Models;

namespace Fights.Api.Controllers
{
    [Route("api/protests")]
    public class ProtestController : BaseController
    {

        private readonly IProtestRepository protestRepository;
        private readonly IMapper mapper;

        public ProtestController(
            IProtestRepository protestRepository,
            IMapper mapper
        )
        {
            this.protestRepository = protestRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Protest>> GetAll([FromQuery] string search)
        {
            var protests = this.protestRepository.GetAll(search);
            return Ok(protests);
        }

        [HttpGet("{id}")]
        public ActionResult<ProtestDetail> GetOne(long id)
        {
            var entity = this.protestRepository.GetOne(id);
            var protest = this.mapper.Map<ProtestDetail>(entity);
            return Ok(protest);
        }

        [HttpPut("{id}")]
        public ActionResult<Protest> Put(long id, Protest p)
        {
            var protest = this.protestRepository.Update(id, p);
            return Ok(protest);
        }

        [HttpDelete("{id}")]
        public ActionResult<Protest> Delete(long id)
        {
            this.protestRepository.Delete(id);
            return Ok();
        }


    }
}
