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
                    LicensePlate = "ZG 007 JB",
                    CarId = 1
                },
                new Driver
                {
                    Id = 2,
                    LicensePlate = "RI 237 KS",
                    CarId = 2
                },
                new Driver
                {
                    Id = 3,
                    LicensePlate = "ZG 173 SS",
                    CarId = 3
                },
                new Driver
                {
                    Id = 4,
                    LicensePlate = "KC 981 SD",
                    CarId = 4
                }
            );
        }
    }
}