using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Parking.Data.Entities
{
    public class PaymentPanel : BaseEntity
    {
        [Required]
        public int PayedForHours{get;set;}
        [Required]
        public DateTime ChargingStart{get;set;}
        public long ParkedId { get; set; }
        public Parked Parked;
        public ICollection<Payment> Payments { get; set; }
    }
}