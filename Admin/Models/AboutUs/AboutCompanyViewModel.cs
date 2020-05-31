using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Models.AboutUs
{
    public class AboutCompanyViewModel
    {
        public int Id { get; set; }
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
        public string AddedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool Status { get; set; }


        public ICollection<AboutCompanyEncourageViewModel> Encourages { get; set; }
        public ICollection<AboutCompanyFunFactViewModel> FunFacts { get; set; }
    }
}
