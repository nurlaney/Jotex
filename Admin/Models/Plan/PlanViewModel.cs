using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Models.Plan
{
    public class PlanViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public string ActionText { get; set; }
        public int? LabelId { get; set; }
        public string AddedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool Status { get; set; }


        public LabelViewModel Label { get; set; }
        public ICollection<PlanDetailViewModel> Details { get; set; }
    }
}
