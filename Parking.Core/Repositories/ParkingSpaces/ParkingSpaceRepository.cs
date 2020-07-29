using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Parking.Data.Database;
using Parking.Data.Entities;

namespace Parking.Core.Repositories.ParkingSpaces
{
    public class ParkingSpaceRepository : IParkingSpaceRepository
    {
        private readonly ParkingContext context;

        public ParkingSpaceRepository(ParkingContext context)
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
        public ParkingSpace Update(long id, ParkingSpace newParkingSpace)
        {
            newParkingSpace.Id = id;
            this.context.Entry(newParkingSpace).State = EntityState.Modified;
            this.context.SaveChanges();

            return newParkingSpace;
        }
    }
}