using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Models
{
   public class AboutCompanyFunFact : BaseEntity
    {
        [Required]
        [MaxLength(65)]
        public string Icon { get; set; }
        [Required]
        [MaxLength(50)]
        public string Numbs { get; set; }
        [Required]
        [MaxLength(65)]
        public string Description { get; set; }
    }
}
