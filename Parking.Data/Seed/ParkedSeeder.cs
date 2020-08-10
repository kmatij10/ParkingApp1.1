using Microsoft.EntityFrameworkCore;
using Parking.Data.Entities;

namespace Parking.Data.Seed
{
    public static class ParkedSeeder
    {
        public static void SeedParked(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Parked>().HasData(
                new Parked
                {
                    Id = 1,
                    From = new System.DateTime(2020,8,11),
                    To = new System.DateTime(2020,8,14),
                    DriverId = 1,
                    RequestStatusId = 1,
                    ParkingSpaceId = 1
                },
                new Parked
                {
                    Id = 2,
                    From = new System.DateTime(2020,10,11),
                    To = new System.DateTime(2020,10,14),
                    DriverId = 1,
                    RequestStatusId = 1,
                    ParkingSpaceId = 1
                },
                new Parked
                {
                    Id = 3,
                    From = new System.DateTime(2019,3,15),
                    To = new System.DateTime(2019,4,20),
                    DriverId = 1,
                    RequestStatusId = 1,
                    ParkingSpaceId = 1
                }
            );
        }
    }
}