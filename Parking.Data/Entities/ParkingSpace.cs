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
        public long ParkingTypeId { get; set; }
        public long RateId { get; set; }
        public ParkingType ParkingType;
        public Rate Rate;
        public ICollection<Parked> Parked { get; set; }
    }
}