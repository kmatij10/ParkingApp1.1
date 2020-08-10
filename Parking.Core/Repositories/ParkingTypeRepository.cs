using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Parking.Data.Database;
using Parking.Data.Entities;

namespace Parking.Core.Repositories
{
    public interface IParkingTypeRepository : IRepository<ParkingType>
    {
        public ParkingType Patch(long id, JsonPatchDocument<ParkingType> doc);
    }
    public class ParkingTypeRepository : IParkingTypeRepository
    {
        private readonly ApplicationContext context;

        public ParkingTypeRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public IEnumerable<ParkingType> GetAll(string search)
        {
            return this.context.ParkingTypes.ToList();
        }
        public ParkingType GetOne(long id)
        {
            return this.context.ParkingTypes.Where(c => c.Id == id).Single();
        }
        public ParkingType Create(ParkingType c)
        {
            this.context.ParkingTypes.Add(c);
            this.context.SaveChanges();

            return c;
        }
        public bool Delete(long id)
        {
            this.context.ParkingTypes.Remove(this.GetOne(id));
            this.context.SaveChanges();
            return true;
        }
        public ParkingType Patch(long id, JsonPatchDocument<ParkingType> doc)
        {
            var parkingType = this.GetOne(id);
            doc.ApplyTo(parkingType);
            this.context.SaveChanges();
            return parkingType;
        }
    }
}