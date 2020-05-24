using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Models
{
   public class Tag : BaseEntity
    {
        [Required]
        [MaxLength(60)]
        public string Name { get; set; }

       public ICollection<Blog> Blogs { get; set; }
    }
}
