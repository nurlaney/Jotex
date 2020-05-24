using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories.CaseStudyRepositories
{
   public interface ICaseStudyRepository
    {
        public IEnumerable<CaseStudy> GetCaseStudies();
        public CaseStudy GetCaseStudyById(int id);
        public IEnumerable<CaseStudy> GetCaseStudiesByServiceId(int serviceId, int take);
    }
}
