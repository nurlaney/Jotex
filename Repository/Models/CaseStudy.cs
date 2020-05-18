using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Models
{
  public class CaseStudy : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(150)]
        public string Title { get; set; }
        [Required]
        [MaxLength(250)]
        public string Description { get; set; }
        [Required]
        [MaxLength(550)]
        public string Text { get; set; }

        public int AgentId { get; set; }

        public ICollection<CaseStudySpec> CaseStudySpecs { get; set; }
        public ICollection<CaseStudyProcess> CaseStudyProcesses { get; set; }

        public Agent Agent { get; set; }
    }
}
