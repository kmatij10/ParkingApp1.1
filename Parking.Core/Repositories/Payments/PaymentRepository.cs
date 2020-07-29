using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Parking.Data.Database;
using Parking.Data.Entities;

namespace Parking.Core.Repositories.Payments
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ParkingContext context;

        public PaymentRepository(ParkingContext context)
        {
            this.context = context;
        }

        public IEnumerable<Payment> GetAll(string search)
        {
            return this.context.Payments.ToList();
        }
        public Payment GetOne(long id)
        {
            return this.context.Payments.Where(c => c.Id == id).Single();
        }

        public Payment Create(Payment c)
        {
            this.context.Payments.Add(c);
            this.context.SaveChanges();

            return c;
        }
        public bool Delete(long id)
        {
            this.context.Payments.Remove(this.GetOne(id));
            this.context.SaveChanges();
            return true;
        }
        public Payment Update(long id, Payment newPayment)
        {
            newPayment.Id = id;
            this.context.Entry(newPayment).State = EntityState.Modified;
            this.context.SaveChanges();

            return newPayment;
        }
    }
}