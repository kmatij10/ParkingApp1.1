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
                    Lat = 50.358398M,
                    Lng = 5.285080M,
                    ParkingTypeId = 1,
                    RateId = 1
                },
                new ParkingSpace
                {
                    Id = 2,
                    Lat = 45.800440M,
                    Lng = 15.994100M,
                    ParkingTypeId = 1,
                    RateId = 1
                },
                new ParkingSpace
                {
                    Id = 3,
                    Lat = 45.808190M,
                    Lng = 15.918490M,
                    ParkingTypeId = 1,
                    RateId = 1
                }
            );
        }
    }
}