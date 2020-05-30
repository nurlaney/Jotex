using Admin.Models.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Models.CaseStudy
{
    public class CaseStudyViewModel
    {
        [Required(ErrorMessage ="vacibdir")]
        public bool Status { get; set; }
        public int Id { get; set; }
        public string AddedBy { get; set; }
        public string ModifiedBy { get; set; }
        [Required(ErrorMessage = "vacibdir")]
        [MaxLength(50,ErrorMessage ="maksimum 50")]
        public string Name { get; set; }
        [Required(ErrorMessage = "vacibdir")]
        [MaxLength(150, ErrorMessage = "maksimum 150")]
        public string Title { get; set; }
        [Required(ErrorMessage = "vacibdir")]
        [MaxLength(250, ErrorMessage = "maksimum 250")]
        public string Description { get; set; }
        [Required(ErrorMessage = "vacibdir")]
        [MaxLength(550, ErrorMessage = "maksimum 550")]
        public string Text { get; set; }
        [Required(ErrorMessage = "vacibdir")]
        [MaxLength(550, ErrorMessage = "maksimum 550")]
        public string Challenge { get; set; }
        [Required(ErrorMessage = "vacibdir")]
        [MaxLength(550, ErrorMessage = "maksimum 550")]
        public string Solution { get; set; }
        [Required(ErrorMessage = "vacibdir")]
        [MaxLength(550, ErrorMessage = "maksimum 550")]
        public string Results { get; set; }

        public int AgentId { get; set; }
        public int ServiceId { get; set; }



        public ICollection<CaseStudySpecViewModel> CaseStudySpecs { get; set; }

        public AgentViewModel Agent { get; set; }
        public ServiceViewModel Service { get; set; }
    }
}
