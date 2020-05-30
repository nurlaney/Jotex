using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Models.Plan
{
    public class LabelViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(55)]
        public string Text { get; set; }
        [Required]
        [MaxLength(55)]
        public string Color { get; set; }
        public string AddedBy { get; set; }
        public string ModifiedBy { get; set; }
        [Required]
        public bool Status { get; set; }

        public ICollection<PlanViewModel> Plans { get; set; }
    }
}
