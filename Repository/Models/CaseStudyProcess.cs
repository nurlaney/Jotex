using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Models
{
   public class CaseStudyProcess : BaseEntity
    {
        public string Challenge { get; set; }
        public string Solution { get; set; }
        public string Results { get; set; }

        public int CaseStudyId { get; set; }


        public CaseStudy CaseStudy { get; set; }
    }
}
