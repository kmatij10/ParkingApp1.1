using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Parking.Data.Database;
using Parking.Data.Entities;

namespace Parking.Core.Repositories
{
    public interface IDriverRepository : IRepository<Driver>
    {
        public Driver Patch(long id, JsonPatchDocument<Driver> doc);
    }
    public class DriverRepository : IDriverRepository
    {
        private readonly ApplicationContext context;

        public DriverRepository(ApplicationContext context)
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
        public Driver Patch(long id, JsonPatchDocument<Driver> doc)
        {
            var driver = this.GetOne(id);
            doc.ApplyTo(driver);
            this.context.SaveChanges();
            return driver;
        }
    }
}