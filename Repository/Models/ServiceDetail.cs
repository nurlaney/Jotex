using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Models
{
   public class ServiceDetail : BaseEntity
    {
        public int ServiceId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(550)]
        public string Text { get; set; }
        [Required]
        [MaxLength(300)]
        public string Description { get; set; }
        [Required]
        [MaxLength(100)]
        public string Image { get; set; }

        public Service Service { get; set; }
    }
}
