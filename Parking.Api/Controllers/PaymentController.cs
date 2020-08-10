using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Parking.Core.Repositories;
using Parking.Data.Entities;

namespace Parking.Api.Controllers
{
    [ApiController]
    [Route("api/payments")]
    public class PaymentController : BaseController
    {
        private readonly IPaymentRepository paymentRepository;
        private readonly IMapper mapper;

        public PaymentController(
            IPaymentRepository paymentRepository,
            IMapper mapper
        )
        {
            this.paymentRepository = paymentRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Payment>> GetAll([FromQuery] string search)
        {
            var payment = this.paymentRepository.GetAll(search);
            return Ok(payment);
        }

        [HttpGet("{id}")]
        public ActionResult<Payment> GetOne(long id)
        {
            var entity = this.paymentRepository.GetOne(id);
            var payment = this.mapper.Map<Payment>(entity);
            return Ok(payment);
        }

        [HttpPost]
        public ActionResult<Payment> Create(Payment c)
        {
            var payment = this.mapper.Map<Payment>(c);
            payment = this.paymentRepository.Create(payment);
            return this.mapper.Map<Payment>(payment);
        }

        [HttpPatch("{id}")]
        public ActionResult<Payment> Patch(int id, [FromBody]JsonPatchDocument<Payment> doc)
        {
            var payment = this.paymentRepository.GetOne(id);
            this.paymentRepository.Patch(id, doc);
            return Ok(payment);
        }
        [HttpDelete("{id}")]
        public ActionResult<Payment> Delete(long id)
        {
            this.paymentRepository.Delete(id);
            return Ok();
        }
    }
}