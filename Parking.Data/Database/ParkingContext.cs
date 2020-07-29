using Microsoft.EntityFrameworkCore;
using Parking.Data.Entities;
using System;

namespace Parking.Data.Database
{
    public class ParkingContext : DbContext
    {
        public ParkingContext(DbContextOptions<ParkingContext> options)
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasData(
                new Car
                {
                    Id = 1,
                    Model = "Chevrolet Aveo"
                },
                new Car
                {
                    Id = 2,
                    Model = "Opel Corsa"
                },
                new Car
                {
                    Id = 3,
                    Model = "Renault Clio"
                }
            );
            modelBuilder.Entity<Driver>().HasData(
                new Driver
                {
                    Id = 1,
                    LicensePlate = "lalalalal",
                    CarId = 1
                },
                new Driver
                {
                    Id = 2,
                    LicensePlate = "nanananna",
                    CarId = 1
                },
                new Driver
                {
                    Id = 3,
                    LicensePlate = "blblblbl",
                    CarId = 1
                }
            );
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
