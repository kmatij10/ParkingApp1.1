using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Protests.Data.Entities
{
    public class Organizer : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        public ICollection<Protest> Protests { get; set; }
    }
}