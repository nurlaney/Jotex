using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Models
{
   public class ServiceBanner : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Logo { get; set; }
        [Required]
        [MaxLength(60)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
    }
}
