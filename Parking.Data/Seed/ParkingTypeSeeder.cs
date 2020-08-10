using Microsoft.EntityFrameworkCore;
using Parking.Data.Entities;

namespace Parking.Data.Seed
{
    public static class ParkingTypeSeeder
    {
        public static void SeedParkingTypes(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParkingType>().HasData(
                new ParkingType
                {
                    Id = 1,
                    Type = "handicapped",
                    Zone = 2
                },
                new ParkingType
                {
                    Id = 2,
                    Type = "regular",
                    Zone = 2
                },
                new ParkingType
                {
                    Id = 3,
                    Type = "handicapped",
                    Zone = 2
                }
            );
        }
    }
}