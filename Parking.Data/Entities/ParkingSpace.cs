using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Parking.Data.Entities
{
    public class ParkingSpace : BaseEntity
    {
        [Required]
        public double Lat{get;set;}
        [Required]
        public double Lng{get;set;}
        public long ParkingTypeId { get; set; }
        public long RateId { get; set; }
        public ParkingType ParkingType;
        public Rate Rate;
        public ICollection<Parked> Parked { get; set; }
    }
}