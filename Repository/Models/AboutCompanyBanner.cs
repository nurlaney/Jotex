using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Models
{
   public class AboutCompanyBanner : BaseEntity
    {
        [Required]
        [MaxLength(65)]
        public string Icon { get; set; }
        [Required]
        [MaxLength(50)]
        public string Option { get; set; }
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
    }
}
