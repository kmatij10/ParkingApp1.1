using Microsoft.EntityFrameworkCore;
using Parking.Data.Entities;

namespace Parking.Data.Seed
{
    public static class CarSeeder
    {
        public static void SeedCars(this ModelBuilder modelBuilder)
        {
             modelBuilder.Entity<Car>().HasData(
                new Car
                {
                    Id = 1,
                    Model = "Chevrolet Aveo"
                },
                new Car
                {
                    Id = 2,
                    Model = "Opel Corsa"
                },
                new Car
                {
                    Id = 3,
                    Model = "Renault Clio"
                }
            );
        }
    }
}