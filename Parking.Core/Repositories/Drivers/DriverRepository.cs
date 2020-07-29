using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Parking.Data.Database;
using Parking.Data.Entities;

namespace Parking.Core.Repositories.Drivers
{
    public class DriverRepository : IDriverRepository
    {
        private readonly ParkingContext context;

        public DriverRepository(ParkingContext context)
        {
            this.context = context;
        }

        public IEnumerable<Driver> GetAll(string search)
        {
            return this.context.Drivers.ToList();
        }

        public Driver GetOne(long id)
        {
            return this.context.Drivers.Where(c => c.Id == id).Single();
        }

        public Driver Create(Driver c)
        {
            this.context.Drivers.Add(c);
            this.context.SaveChanges();

            return c;
        }
        public bool Delete(long id)
        {
            this.context.Drivers.Remove(this.GetOne(id));
            this.context.SaveChanges();
            return true;
        }
        public Driver Update(long id, Driver newDriver)
        {
            newDriver.Id = id;
            this.context.Entry(newDriver).State = EntityState.Modified;
            this.context.SaveChanges();

            return newDriver;
        }
    }
}