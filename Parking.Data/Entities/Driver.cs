using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Parking.Data.Entities
{
    public class Driver : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string LicensePlate { get; set; }

        [Required]
        public long CarId { get; set; }
        public Car Car { get; set; }
        public ICollection<Parked> Parked { get; set; }
    }
}