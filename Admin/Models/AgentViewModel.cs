using Admin.Models.CaseStudy;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Models
{
    public class AgentViewModel
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public string AddedBy { get; set; }
        public string ModifiedBy { get; set; }
        [Required]
        [MaxLength(35)]
        public string Name { get; set; }
        [Required]
        [MaxLength(45)]
        public string Position { get; set; }
        [Required]
        [MaxLength(75)]
        public string Image { get; set; }

        public ICollection<CaseStudyViewModel> CaseStudies { get; set; }
    }
}
