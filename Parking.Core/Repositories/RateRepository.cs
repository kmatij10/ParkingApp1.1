using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Parking.Data.Database;
using Parking.Data.Entities;

namespace Parking.Core.Repositories
{
    public interface IRateRepository : IRepository<Rate>
    {
        public Rate Patch(long id, JsonPatchDocument<Rate> doc);
    }
    public class RateRepository : IRateRepository
    {
        private readonly ApplicationContext context;

        public RateRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public IEnumerable<Rate> GetAll(string search)
        {
            return this.context.Rates.ToList();
        }
        public Rate GetOne(long id)
        {
            return this.context.Rates.Where(c => c.Id == id).Single();
        }
        public Rate Create(Rate c)
        {
            this.context.Rates.Add(c);
            this.context.SaveChanges();

            return c;
        }
        public bool Delete(long id)
        {
            this.context.Rates.Remove(this.GetOne(id));
            this.context.SaveChanges();
            return true;
        }
        public Rate Patch(long id, JsonPatchDocument<Rate> doc)
        {
            var rate = this.GetOne(id);
            doc.ApplyTo(rate);
            this.context.SaveChanges();
            return rate;
        }
    }
}