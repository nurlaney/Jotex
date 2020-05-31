using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Models.AboutUs
{
    public class AboutCompanyEncourageViewModel
    {
        public int Id { get; set; }
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
        public string AddedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool Status { get; set; }

        public AboutCompanyViewModel AboutCompany { get; set; }
    }
}
