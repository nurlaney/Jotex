using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Models.Plan
{
    public class PlanViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(50)]
        public string Icon { get; set; }
        [Required]
        [MaxLength(100)]
        public string ActionText { get; set; }
        public int? LabelId { get; set; }
        public string AddedBy { get; set; }
        public string ModifiedBy { get; set; }
        [Required]
        public bool Status { get; set; }


        public LabelViewModel Label { get; set; }
        public ICollection<PlanDetailViewModel> Details { get; set; }
    }
}
