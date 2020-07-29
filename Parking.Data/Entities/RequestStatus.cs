using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Parking.Data.Entities
{
    public class RequestStatus : BaseEntity
    {
        [Required]
        public string Name{get;set;}
        public ICollection<Parked> Parked { get; set; }
    }
}