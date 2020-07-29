using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Parking.Data.Entities
{
    public class Rate : BaseEntity
    {
        [Required]
        public decimal PriceHourly{get;set;}
        public ICollection<ParkingSpace> ParkingSpaces { get; set; }
    }
}