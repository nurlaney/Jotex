using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Models.Plan
{
    public class PlanDetailViewModel
    {
        public int Id { get; set; }
        public string Condition { get; set; }
        public string AddedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool Status { get; set; }
        public int PlanId { get; set; }
        public PlanViewModel Plan { get; set; }
    }
}
