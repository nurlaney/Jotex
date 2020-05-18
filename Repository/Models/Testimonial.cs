using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Models
{
   public class Testimonial : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string WriterName { get; set; }
        [Required]
        [MaxLength(60)]
        public string WriterDesc { get; set; }
        [Required]
        [MaxLength(550)]
        public string Text { get; set; }
    }
}
