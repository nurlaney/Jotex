using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Models
{
   public class CoveredContact : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(400)]
        public string Text { get; set; }
        [Required]
        [MaxLength(60)]
        public string ActionText { get; set; }
        [Required]
        [MaxLength(100)]
        public string Image { get; set; }
    }
}
