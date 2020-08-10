using System;

namespace Parking.Data.Models
{
    public class UserDetail
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string FirstName { get; set;}
        public string LastName { get; set; }

        public string FullName { get {
            return $"{this.LastName} {this.FirstName}";
        } }

        public string Email { get; set; }
    }
}