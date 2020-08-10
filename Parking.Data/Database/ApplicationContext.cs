using Microsoft.EntityFrameworkCore;
using Parking.Data.Entities;
using Parking.Data.Seed;
using System;

namespace Parking.Data.Database
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Parked> Parked { get; set; }
        public DbSet<ParkingSpace> ParkingSpaces { get; set; }
        public DbSet<ParkingType> ParkingTypes { get; set; }
        public DbSet<PaymentPanel> PaymentPanels { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<RequestStatus> RequestStatuses { get; set; }
        public DbSet<AppUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedCars();
            modelBuilder.SeedDrivers();
            modelBuilder.SeedParked();
            modelBuilder.SeedParkingSpaces();
            modelBuilder.SeedParkingTypes();
            modelBuilder.SeedPaymentPanels();
            modelBuilder.SeedPayments();
            modelBuilder.SeedRates();
            modelBuilder.SeedRequestStatuses();
        }
    }
}
