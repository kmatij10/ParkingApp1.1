using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;
using Parking.Data.Database;
using Parking.Data.Entities;

namespace Parking.Core.Repositories
{
    public interface IAvailabilityRepository :IRepository<Availability>
    {
        public Availability Patch(long id, JsonPatchDocument<Availability> doc);
    }
    public class AvailabilityRepository: IAvailabilityRepository
    {
        private readonly ApplicationContext context;

        public AvailabilityRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public Availability GetOne(long id)
        {
            return this.context.Availabilities.Where(c => c.Id == id).Single();
        }
        public IEnumerable<Availability> GetAll(string search)
        {
            return this.context.Availabilities.ToList();
        }
        public bool Delete(long id)
        {
            this.context.Availabilities.Remove(this.GetOne(id));
            this.context.SaveChanges();
            return true;
        }
        public Availability Create(Availability c)
        {
            this.context.Availabilities.Add(c);
            this.context.SaveChanges();

            return c;
        }
        public Availability Patch(long id, JsonPatchDocument<Availability> doc)
        {
            var availability = this.GetOne(id);
            doc.ApplyTo(availability);
            this.context.SaveChanges();
            return availability;
        }
    }
}