using Microsoft.EntityFrameworkCore;
using Parking.Data.Entities;

namespace Parking.Data.Seed
{
    public static class DriverSeeder
    {
        public static void SeedDrivers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Driver>().HasData(
                new Driver
                {
                    Id = 1,
                    LicensePlate = "lalalalal",
                    CarId = 1
                },
                new Driver
                {
                    Id = 2,
                    LicensePlate = "nanananna",
                    CarId = 1
                },
                new Driver
                {
                    Id = 3,
                    LicensePlate = "blblblbl",
                    CarId = 1
                }
            );
        }
    }
}