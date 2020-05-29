using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Models
{
   public class Service : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Logo { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(550)]
        public string Text { get; set; }

        [MaxLength(100)]
        public string Image { get; set; }

        public ICollection<CaseStudy> CaseStudies { get; set; }
        public ICollection<ServiceSpec> ServiceSpecs { get; set; }
        public ICollection<Blog> Blogs { get; set; }
    }
}
