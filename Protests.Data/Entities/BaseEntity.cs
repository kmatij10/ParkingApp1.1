using System;
using System.Collections.Generic;
using System.Text;

namespace Protests.Data.Entities
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
