using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Models
{
   public class BlogWriter : BaseEntity
    {
        [Required]
        [MaxLength(60)]
        public string Name { get; set; }
        [Required]
        [MaxLength(350)]
        public string Description { get; set; }
        [MaxLength(60)]
        public string Image { get; set; }

        public ICollection<Blog> Blogs { get; set; }
    }
}
