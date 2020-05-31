using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Models
{
   public class LikeableArea : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(300)]
        public string Text { get; set; }

        [MaxLength(100)]
        public string Image { get; set; }
    }
}
