
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Fights.Core.Repositories.Organizers;
using Fights.Data.Entities;

namespace Fights.Api.Controllers
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