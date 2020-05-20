using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jotex.Models
{
    public class PlanViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public string Condition { get; set; }
        public string ActionText { get; set; }
        public int LabelId { get; set; }

        public LabelViewModel Label { get; set; }

        public IList<String> PlanDetails { get; set; }
    }
}
