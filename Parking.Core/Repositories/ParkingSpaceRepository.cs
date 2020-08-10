using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Parking.Data.Database;
using Parking.Data.Entities;

namespace Parking.Core.Repositories
{
    public interface IParkingSpaceRepository : IRepository<ParkingSpace>
    {
        public ParkingSpace Patch(long id, JsonPatchDocument<ParkingSpace> doc);
    }
    public class ParkingSpaceRepository : IParkingSpaceRepository
    {
        private readonly ApplicationContext context;

        public ParkingSpaceRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public IEnumerable<ParkingSpace> GetAll(string search)
        {
            return this.context.ParkingSpaces.ToList();
        }
        public ParkingSpace GetOne(long id)
        {
            return this.context.ParkingSpaces.Where(c => c.Id == id).Single();
        }

        public ParkingSpace Create(ParkingSpace c)
        {
            this.context.ParkingSpaces.Add(c);
            this.context.SaveChanges();

            return c;
        }
        public bool Delete(long id)
        {
            this.context.ParkingSpaces.Remove(this.GetOne(id));
            this.context.SaveChanges();
            return true;
        }
        public ParkingSpace Patch(long id, JsonPatchDocument<ParkingSpace> doc)
        {
            var parkingSpace = this.GetOne(id);
            doc.ApplyTo(parkingSpace);
            this.context.SaveChanges();
            return parkingSpace;
        }
    }
}