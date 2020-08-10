using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Parking.Data.Database;
using Parking.Data.Entities;

namespace Parking.Core.Repositories
{
    public interface ICarRepository :IRepository<Car>
    {
        public Car Patch(long id, JsonPatchDocument<Car> doc);
    }
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationContext context;

        public CarRepository(ApplicationContext context)
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
        public Car Patch(long id, JsonPatchDocument<Car> doc)
        {
            var car = this.GetOne(id);
            doc.ApplyTo(car);
            this.context.SaveChanges();
            return car;
        }
    }
}