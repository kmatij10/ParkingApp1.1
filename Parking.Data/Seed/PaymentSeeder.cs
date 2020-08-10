using Microsoft.EntityFrameworkCore;
using Parking.Data.Entities;

namespace Parking.Data.Seed
{
    public static class PaymentSeeder
    {
        public static void SeedPayments(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>().HasData(
                new Payment
                {
                    Id = 1,
                    IssuedAt = new System.DateTime(2020,7,24),
                    Amount = 3_000.5m,
                    Status = "status",
                    PaymentPanelId = 2
                },
                new Payment
                {
                    Id = 2,
                    IssuedAt = new System.DateTime(2019,10,14),
                    Amount = 1_066.1m,
                    Status = "status2",
                    PaymentPanelId = 2
                },
                new Payment
                {
                    Id = 3,
                    IssuedAt = new System.DateTime(2020,8,11),
                    Amount = 3_111.9m,
                    Status = "status3",
                    PaymentPanelId = 2
                }
            );
        }
    }
}