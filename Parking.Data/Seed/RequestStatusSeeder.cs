using Microsoft.EntityFrameworkCore;
using Parking.Data.Entities;

namespace Parking.Data.Seed
{
    public static class RequestStatusSeeder
    {
        public static void SeedRequestStatuses(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RequestStatus>().HasData(
                new RequestStatus
                {
                    Id = 1,
                    Name = "neki status"
                },
                new RequestStatus
                {
                    Id = 2,
                    Name = "drugi status"
                },
                new RequestStatus
                {
                    Id = 3,
                    Name = "treci status"
                }
            );
        }
    }
}