using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Parking.Data.Entities
{
    public class ParkingType : BaseEntity
    {
        [Required]
        public string Type{get;set;}
        [Required]
        public int Zone{get;set;}
        public ICollection<ParkingSpace> ParkingSpaces { get; set; }
    }
}