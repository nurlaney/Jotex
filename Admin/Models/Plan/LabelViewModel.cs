using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Models.Plan
{
    public class LabelViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Color { get; set; }
        public string AddedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool Status { get; set; }

        public ICollection<PlanViewModel> Plans { get; set; }
    }
}
