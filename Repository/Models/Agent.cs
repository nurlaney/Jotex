using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Models
{
   public class Agent : BaseEntity
    {
        [Required]
        [MaxLength(35)]
        public string Name { get; set; }
        [Required]
        [MaxLength(45)]
        public string Position { get; set; }
        [Required]
        [MaxLength(75)]
        public string Image { get; set; }

        public ICollection<CaseStudy> CaseStudies { get; set; }
    }
}
