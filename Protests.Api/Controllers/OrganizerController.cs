
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Protests.Core.Repositories.Organizers;
using Protests.Data.Entities;

namespace Protests.Api.Controllers
{
    [Route("api/organizers")]
    public class OrganizerController : BaseController
    {
        private readonly IOrganizerRepository organizerRepository;
        private readonly IMapper mapper;

        public OrganizerController(
            IOrganizerRepository organizerRepository,
            IMapper mapper
        )
        {
            this.organizerRepository = organizerRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Organizer>> GetAll()
        {
            var organizers = this.organizerRepository.GetAll(null);
            return Ok(organizers);
        }


    }
}