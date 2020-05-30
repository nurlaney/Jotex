using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Models.CaseStudy
{
    public class CaseStudySpecViewModel
    {
        public int Id { get; set; }
        [Required]
        public bool Status { get; set; }
        public string AddedBy { get; set; }
        public string ModifiedBy { get; set; }
        [Required]
        [MaxLength(50)]
        public string Key { get; set; }
        [Required]
        [MaxLength(500)]
        public string Value { get; set; }

        public int CaseStudyId { get; set; }


        public CaseStudyViewModel CaseStudy { get; set; }
    }
}
