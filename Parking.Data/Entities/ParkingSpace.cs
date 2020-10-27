using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parking.Data.Entities
{
    public class ParkingSpace : BaseEntity
    {
        [Required]
         [Column(TypeName = "decimal(11, 8)")]
        public decimal Lat{get;set;}
        [Required]
         [Column(TypeName = "decimal(11, 8)")]
        public decimal Lng{get;set;}
        [Required]
        public int Hours{get;set;}
        [Required]
        public DateTime Start{get;set;}
        public long ParkingTypeId { get; set; }
        public long RateId { get; set; }
        public long AvailabilityId { get; set; }
        public long DriverId { get; set; }
        public Driver Driver;
        public Availability Availability;
        public ParkingType ParkingType { get; set; }
        public Rate Rate { get; set; }
        public ICollection<Parked> Parked { get; set; }
    }
}