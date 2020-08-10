using Microsoft.EntityFrameworkCore;
using Parking.Data.Entities;

namespace Parking.Data.Seed
{
    public static class PaymentPanelSeeder
    {
        public static void SeedPaymentPanels(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaymentPanel>().HasData(
                new PaymentPanel
                {
                    Id = 1,
                    PayedForHours = 2,
                    ChargingStart = new System.DateTime(2019,3,15),
                    ParkedId = 1
                },
                new PaymentPanel
                {
                    Id = 2,
                    PayedForHours = 4,
                    ChargingStart = new System.DateTime(2020,7,23),
                    ParkedId = 1
                },
                new PaymentPanel
                {
                    Id = 3,
                    PayedForHours = 1,
                    ChargingStart = new System.DateTime(2019,11,3),
                    ParkedId = 1
                }
            );
        }
    }
}