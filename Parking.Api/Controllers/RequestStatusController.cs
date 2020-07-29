using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Parking.Core.Repositories.RequestStatuses;
using Parking.Data.Entities;

namespace Parking.Api.Controllers
{
    [ApiController]
    [Route("api/requeststatuses")]
    public class RequestStatusController : BaseController
    {
        private readonly IRequestStatusRepository requestStatusRepository;
        private readonly IMapper mapper;

        public RequestStatusController(
            IRequestStatusRepository requestStatusRepository,
            IMapper mapper
        )
        {
            this.requestStatusRepository = requestStatusRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RequestStatus>> GetAll([FromQuery] string search)
        {
            var requestStatus = this.requestStatusRepository.GetAll(search);
            return Ok(requestStatus);
        }

        [HttpGet("{id}")]
        public ActionResult<RequestStatus> GetOne(long id)
        {
            var entity = this.requestStatusRepository.GetOne(id);
            var requestStatus = this.mapper.Map<RequestStatus>(entity);
            return Ok(requestStatus);
        }

        [HttpPost]
        public ActionResult<RequestStatus> Create(RequestStatus c)
        {
            var requestStatus = this.mapper.Map<RequestStatus>(c);
            requestStatus = this.requestStatusRepository.Create(requestStatus);
            return this.mapper.Map<RequestStatus>(requestStatus);
        }

        [HttpPut("{id}")]
        public ActionResult<RequestStatus> Put(long id, RequestStatus c)
        {
            var requestStatus = this.requestStatusRepository.Update(id, c);
            return Ok(requestStatus);
        }
        [HttpDelete("{id}")]
        public ActionResult<RequestStatus> Delete(long id)
        {
            this.requestStatusRepository.Delete(id);
            return Ok();
        }
    }
}