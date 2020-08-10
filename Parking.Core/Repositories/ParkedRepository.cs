using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Parking.Data.Database;
using Parking.Data.Entities;

namespace Parking.Core.Repositories
{
    public interface IParkedRepository: IRepository<Parked>
    {
        public Parked Patch(long id, JsonPatchDocument<Parked> doc);
    }
    public class ParkedRepository : IParkedRepository
    {
        private readonly ApplicationContext context;

        public ParkedRepository(ApplicationContext context)
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
        public Parked Patch(long id, JsonPatchDocument<Parked> doc)
        {
            var parked = this.GetOne(id);
            doc.ApplyTo(parked);
            this.context.SaveChanges();
            return parked;
        }
    }
}