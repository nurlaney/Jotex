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
        public string SubTitle { get; set; }
        [Required]
        [MaxLength(360)]
        public string Description { get; set; }
        [Required]
        [MaxLength(100)]
        public string EncActionText { get; set; }
        public int AboutCompanyId { get; set; }

        public AboutCompany AboutCompany { get; set; }
    }
}
