using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Models
{
   public class AboutCompanyEncourage : BaseEntity
    {
        [Required]
        [MaxLength(60)]
        public string Count { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(360)]
        public string Description { get; set; }
        [Required]
        [MaxLength(100)]
        public string ActionText { get; set; }
    }
}
