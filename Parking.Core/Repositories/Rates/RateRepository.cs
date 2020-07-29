using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Parking.Data.Database;
using Parking.Data.Entities;

namespace Parking.Core.Repositories.Rates
{
    public class RateRepository : IRateRepository
    {
        private readonly ParkingContext context;

        public RateRepository(ParkingContext context)
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
        public Rate Update(long id, Rate newRate)
        {
            newRate.Id = id;
            this.context.Entry(newRate).State = EntityState.Modified;
            this.context.SaveChanges();

            return newRate;
        }
    }
}