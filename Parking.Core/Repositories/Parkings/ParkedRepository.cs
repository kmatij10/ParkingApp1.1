using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Parking.Data.Database;
using Parking.Data.Entities;

namespace Parking.Core.Repositories.Parkings
{
    public class ParkedRepository : IParkedRepository
    {
        private readonly ParkingContext context;

        public ParkedRepository(ParkingContext context)
        {
            this.context = context;
        }

        public IEnumerable<Parked> GetAll(string search)
        {
            return this.context.Parked.ToList();
        }
        public Parked GetOne(long id)
        {
            return this.context.Parked.Where(c => c.Id == id).Single();
        }
        public Parked Create(Parked c)
        {
            this.context.Parked.Add(c);
            this.context.SaveChanges();

            return c;
        }
        public bool Delete(long id)
        {
            this.context.Parked.Remove(this.GetOne(id));
            this.context.SaveChanges();
            return true;
        }
        public Parked Update(long id, Parked newParked)
        {
            newParked.Id = id;
            this.context.Entry(newParked).State = EntityState.Modified;
            this.context.SaveChanges();

            return newParked;
        }
    }
}