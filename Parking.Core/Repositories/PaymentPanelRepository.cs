using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Parking.Data.Database;
using Parking.Data.Entities;

namespace Parking.Core.Repositories
{
    public interface IPaymentPanelRepository : IRepository<PaymentPanel>
    {
        public PaymentPanel Patch(long id, JsonPatchDocument<PaymentPanel> doc);
    }
    public class PaymentPanelRepository : IPaymentPanelRepository
    {
        private readonly ApplicationContext context;

        public PaymentPanelRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public IEnumerable<PaymentPanel> GetAll(string search)
        {
            return this.context.PaymentPanels.ToList();
        }
        public PaymentPanel GetOne(long id)
        {
            return this.context.PaymentPanels.Where(c => c.Id == id).Single();
        }
        public PaymentPanel Create(PaymentPanel c)
        {
            this.context.PaymentPanels.Add(c);
            this.context.SaveChanges();

            return c;
        }
        public bool Delete(long id)
        {
            this.context.PaymentPanels.Remove(this.GetOne(id));
            this.context.SaveChanges();
            return true;
        }
        public PaymentPanel Patch(long id, JsonPatchDocument<PaymentPanel> doc)
        {
            var paymentPanel = this.GetOne(id);
            doc.ApplyTo(paymentPanel);
            this.context.SaveChanges();
            return paymentPanel;
        }
    }
}