using System.Collections.Generic;

namespace Protests.Data.Entities
{
    public class City : BaseEntity
    {
        public string CityName { get; set; }

        public ICollection<Protest> Protests { get; set; }
    }
}