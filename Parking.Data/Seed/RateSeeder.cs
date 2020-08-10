using Microsoft.EntityFrameworkCore;
using Parking.Data.Entities;

namespace Parking.Data.Seed
{
    public static class RateSeeder
    {
        public static void SeedRates(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rate>().HasData(
                new Rate
                {
                    Id = 1,
                    PriceHourly = 6.1m
                },
                new Rate
                {
                    Id = 2,
                    PriceHourly = 2.1m
                },
                new Rate
                {
                    Id = 3,
                    PriceHourly = 4.6m
                }
            );
        }
    }
}