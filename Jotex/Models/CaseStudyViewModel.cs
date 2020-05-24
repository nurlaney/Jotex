using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jotex.Models
{
    public class CaseStudyViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public string Challenge { get; set; }
        public string Solution { get; set; }
        public string Results { get; set; }

        public ServiceViewModel Service { get; set; }
        public AgentViewModel Agent { get; set; }

        public IList<CaseStudySpecViewModel> CaseStudySpecs { get; set; }
    }
}
