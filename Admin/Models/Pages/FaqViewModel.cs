using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Models.Pages
{
    public class FaqViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="vacibdir")]
        [MaxLength(450, ErrorMessage = "450 xarakterdən çox ola bilməz")]
        public string Question { get; set; }
        [Required(ErrorMessage = "vacibdir")]
        [MaxLength(850, ErrorMessage = "850 xarakterdən çox ola bilməz")]
        public string Answer { get; set; }
        public string AddedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool Status { get; set; }
    }
}
