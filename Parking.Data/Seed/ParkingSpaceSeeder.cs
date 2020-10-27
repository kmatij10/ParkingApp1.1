using Microsoft.EntityFrameworkCore;
using Parking.Data.Entities;

namespace Parking.Data.Seed
{
    public static class ParkingSpaceSeeder
    {
        public static void SeedParkingSpaces(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParkingSpace>().HasData(
                new ParkingSpace
                {
                    Id = 1,
                    Lat = 45.810723M,
                    Lng = 15.988867M,
                    Hours = 0,
                    Start = System.DateTime.Now,
                    ParkingTypeId = 1,
                    RateId = 1,
                    AvailabilityId = 1,
                    DriverId = 1
                },
                new ParkingSpace
                {
                    Id = 2,
                    Lat = 45.800440M,
                    Lng = 15.994100M,
                    Hours = 0,
                    Start = System.DateTime.Now,
                    ParkingTypeId = 2,
                    RateId = 3,
                    AvailabilityId = 1,
                    DriverId = 2
                },
                new ParkingSpace
                {
                    Id = 3,
                    Lat = 45.808190M,
                    Lng = 15.918490M,
                    Hours = 1,
                    Start = System.DateTime.Now,
                    ParkingTypeId = 1,
                    RateId = 1,
                    AvailabilityId = 2,
                    DriverId = 3
                },
                new ParkingSpace
                {
                    Id = 4,
                    Lat = 45.807761M,
                    Lng = 15.982902M,
                    Hours = 0,
                    Start = System.DateTime.Now,
                    ParkingTypeId = 1,
                    RateId = 1,
                    AvailabilityId = 1,
                    DriverId = 2
                },
                new ParkingSpace
                {
                    Id = 5,
                    Lat = 45.808317M,
                    Lng = 15.978979M,
                    Hours = 2,
                    Start = System.DateTime.Now,
                    ParkingTypeId = 2,
                    RateId = 2,
                    AvailabilityId = 2,
                    DriverId = 3
                }
            );
        }
    }
}