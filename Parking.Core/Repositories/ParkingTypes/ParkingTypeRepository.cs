using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Parking.Data.Database;
using Parking.Data.Entities;

namespace Parking.Core.Repositories.ParkingTypes
{
    public class ParkingTypeRepository : IParkingTypeRepository
    {
        private readonly ParkingContext context;

        public ParkingTypeRepository(ParkingContext context)
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
        public ParkingType Update(long id, ParkingType newParkingType)
        {
            newParkingType.Id = id;
            this.context.Entry(newParkingType).State = EntityState.Modified;
            this.context.SaveChanges();

            return newParkingType;
        }
    }
}