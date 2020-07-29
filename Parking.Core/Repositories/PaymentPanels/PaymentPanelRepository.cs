using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Parking.Data.Database;
using Parking.Data.Entities;

namespace Parking.Core.Repositories.PaymentPanels
{
    public class PaymentPanelRepository : IPaymentPanelRepository
    {
        private readonly ParkingContext context;

        public PaymentPanelRepository(ParkingContext context)
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
        public PaymentPanel Update(long id, PaymentPanel newPaymentPanel)
        {
            newPaymentPanel.Id = id;
            this.context.Entry(newPaymentPanel).State = EntityState.Modified;
            this.context.SaveChanges();

            return newPaymentPanel;
        }
    }
}