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
                    Lat = 20.3,
                    Lng = 13.3,
                    ParkingTypeId = 1,
                    RateId = 1
                },
                new ParkingSpace
                {
                    Id = 2,
                    Lat = 40.3,
                    Lng = 30.3,
                    ParkingTypeId = 1,
                    RateId = 1
                },
                new ParkingSpace
                {
                    Id = 3,
                    Lat = -13.3,
                    Lng = 40.3,
                    ParkingTypeId = 1,
                    RateId = 1
                }
            );
        }
    }
}