using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Parking.Core.Repositories.PaymentPanels;
using Parking.Data.Entities;

namespace Parking.Api.Controllers
{
    [ApiController]
    [Route("api/paymentpanels")]
    public class PaymentPanelController : BaseController
    {
        private readonly IPaymentPanelRepository paymentPanelRepository;
        private readonly IMapper mapper;

        public PaymentPanelController(
            IPaymentPanelRepository paymentPanelRepository,
            IMapper mapper
        )
        {
            this.paymentPanelRepository = paymentPanelRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PaymentPanel>> GetAll([FromQuery] string search)
        {
            var paymentPanel = this.paymentPanelRepository.GetAll(search);
            return Ok(paymentPanel);
        }

        [HttpGet("{id}")]
        public ActionResult<PaymentPanel> GetOne(long id)
        {
            var entity = this.paymentPanelRepository.GetOne(id);
            var paymentPanel = this.mapper.Map<PaymentPanel>(entity);
            return Ok(paymentPanel);
        }

        [HttpPost]
        public ActionResult<PaymentPanel> Create(PaymentPanel c)
        {
            var paymentPanel = this.mapper.Map<PaymentPanel>(c);
            paymentPanel = this.paymentPanelRepository.Create(paymentPanel);
            return this.mapper.Map<PaymentPanel>(paymentPanel);
        }

        [HttpPut("{id}")]
        public ActionResult<PaymentPanel> Put(long id, PaymentPanel c)
        {
            var paymentPanel = this.paymentPanelRepository.Update(id, c);
            return Ok(paymentPanel);
        }
        [HttpDelete("{id}")]
        public ActionResult<PaymentPanel> Delete(long id)
        {
            this.paymentPanelRepository.Delete(id);
            return Ok();
        }
    }
}