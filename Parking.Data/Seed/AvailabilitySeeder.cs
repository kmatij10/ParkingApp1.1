using Microsoft.EntityFrameworkCore;
using Parking.Data.Entities;

namespace Parking.Data.Seed
{
    public static class AvailabilitySeeder
    {
        public static void SeedAvailabilities(this ModelBuilder modelBuilder)
        {
             modelBuilder.Entity<Availability>().HasData(
                new Availability
                {
                    Id = 1,
                    Name = "Available"
                },
                new Availability
                {
                    Id = 2,
                    Name = "Unavailable"
                }
            );
        }
    }
}