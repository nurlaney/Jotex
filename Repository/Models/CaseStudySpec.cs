using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Models
{
   public class CaseStudySpec : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Key { get; set; }
        [Required]
        [MaxLength(500)]
        public string Value { get; set; }

        public int CaseStudyId { get; set; }


        public CaseStudy CaseStudy { get; set; }
    }
}
