using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Parking.Data.Entities
{
    public class Availability : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name{get;set;}
        public ICollection<ParkingSpace> ParkingSpace { get; set; }
    }
}