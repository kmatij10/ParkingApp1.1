using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Parking.Data.Database;
using Parking.Data.Entities;

namespace Parking.Core.Repositories.Cars
{
    public class CarRepository : ICarRepository
    {
        private readonly ParkingContext context;

        public CarRepository(ParkingContext context)
        {
            this.context = context;
        }
        public Car GetOne(long id)
        {
            return this.context.Cars.Where(c => c.Id == id).Single();
        }
        public IEnumerable<Car> GetAll(string search)
        {
            return this.context.Cars.ToList();
        }
        public bool Delete(long id)
        {
            this.context.Cars.Remove(this.GetOne(id));
            this.context.SaveChanges();
            return true;
        }
        public Car Create(Car c)
        {
            this.context.Cars.Add(c);
            this.context.SaveChanges();

            return c;
        }
        public Car Update(long id, Car newCar)
        {
            newCar.Id = id;
            this.context.Entry(newCar).State = EntityState.Modified;
            this.context.SaveChanges();

            return newCar;
        }
    }
}