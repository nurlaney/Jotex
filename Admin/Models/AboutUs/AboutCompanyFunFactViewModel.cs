using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Models.AboutUs
{
    public class AboutCompanyFunFactViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(65)]
        public string Icon { get; set; }
        [Required]
        [MaxLength(50)]
        public string Numbs { get; set; }
        [Required]
        [MaxLength(65)]
        public string FFDescription { get; set; }
        public int AboutCompanyId { get; set; }
        public string AddedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool Status { get; set; }

        public AboutCompanyViewModel AboutCompany { get; set; }
    }
}
