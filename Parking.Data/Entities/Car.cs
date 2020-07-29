using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Parking.Data.Entities
{
    public class Car : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Model { get; set; }
        public ICollection<Driver> Drivers { get; set; }
    }
}