using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Protests.Data.Entities
{
    public class Comment : BaseEntity
    {
        [Required]
        [MaxLength(2048)]
        public string CommentText { get; set; }
        public long ProtestId { get; set; }
        public Protest Protest { get; set; }
    }
}
