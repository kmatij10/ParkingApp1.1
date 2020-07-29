using System;
using System.ComponentModel.DataAnnotations;

namespace Parking.Data.Entities
{
    public class Payment : BaseEntity
    {
        [Required]
        public DateTime IssuedAt{get;set;}
        [Required]
        public decimal Amount{get;set;}
        [Required]
        public string Status{get;set;}
        public long PaymentPanelId { get; set; }
        public PaymentPanel PaymentPanel;
    }
}