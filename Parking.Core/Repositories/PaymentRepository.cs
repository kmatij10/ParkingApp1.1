using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Parking.Data.Database;
using Parking.Data.Entities;

namespace Parking.Core.Repositories
{
    public interface IPaymentRepository : IRepository<Payment>
    {
        public Payment Patch(long id, JsonPatchDocument<Payment> doc);
    }
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationContext context;

        public PaymentRepository(ApplicationContext context)
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
        public Payment Patch(long id, JsonPatchDocument<Payment> doc)
        {
            var payment = this.GetOne(id);
            doc.ApplyTo(payment);
            this.context.SaveChanges();
            return payment;
        }
    }
}