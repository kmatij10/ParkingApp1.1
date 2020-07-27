using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Fights.Data.Entities
{
    public class Protest : BaseEntity
    {
        [Required]
        [MaxLength(256)]
        public string Title { get; set; }

        [Required]
        [MaxLength(10000)]
        public string Description { get; set; }

        [Required]
        public DateTime StartsAt { get; set; }

        public long CityId { get; set; }
        public City City { get; set; }

        public long OrganizerId { get; set; }
        public Organizer Organizer { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
