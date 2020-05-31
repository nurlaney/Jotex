using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Models
{
   public class Blog : BaseEntity
    {
        [Required]
        [MaxLength(150)]
        public string Title { get; set; }
        [Required]
        [MaxLength(6666)]
        public string Text { get; set; }
        [MaxLength(60)]
        public string Image { get; set; }
        public int? TagId { get; set; }
        public int ServiceId { get; set; }
        public int BlogWriterId { get; set; }
        public Service Service { get; set; }
        public BlogWriter BlogWriter { get; set; }
        public Tag Tag { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
