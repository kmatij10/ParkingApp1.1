using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Parking.Data.Entities
{
    public class Parked : BaseEntity
    {
        [Required]
        public DateTime From{get;set;}
        [Required]
        public DateTime To{get;set;}
        public long DriverId { get; set; }
        public long RequestStatusId { get; set; }
        public long ParkingSpaceId { get; set; }
        public Driver Driver;
        public RequestStatus RequestStatus;
        public ParkingSpace ParkingSpace;
        public ICollection<PaymentPanel> PaymentPanels { get; set; }
    }
}