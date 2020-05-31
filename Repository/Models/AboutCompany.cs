using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Models
{
   public class AboutCompany : BaseEntity
    {
        [Required]
        [MaxLength(150)]
        public string Title { get; set; }
        [Required]
        [MaxLength(350)]
        public string Text { get; set; }
        [Required]
        [MaxLength(60)]
        public string ActionText { get; set; }
        [Required]
        [MaxLength(150)]
        public string LeftTitle { get; set; }
        [Required]
        [MaxLength(350)]
        public string LeftText { get; set; }
        [MaxLength(55)]
        public string Image { get; set; }


        public ICollection<AboutCompanyEncourage> Encourages { get; set; }
        public ICollection<AboutCompanyFunFact> FunFacts { get; set; }
    }
}
