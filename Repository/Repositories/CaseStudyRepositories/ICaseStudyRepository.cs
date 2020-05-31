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
        public IEnumerable<CaseStudy> GetAllCaseStudies();
        public IEnumerable<Agent> GetAllAgents();
        public CaseStudy CreateCaseStudy(CaseStudy model);
        public CaseStudy GetAllCaseStudyById(int id);
        public void UpdateCase(CaseStudy caseToUpdate, CaseStudy caseStudy);
        public void DeleteCase(CaseStudy caseStudy);
        public IEnumerable<CaseStudySpec> GetAllCaseStudySpecs();
        public CaseStudySpec CreateCaseStudySpec(CaseStudySpec model);
        public CaseStudySpec GetAllCaseStudySpecsById(int id);
        public void UpdateCaseStudySpec(CaseStudySpec detailToUpdate, CaseStudySpec caseStudySpec);
        public void DeleteCaseStudySpec(CaseStudySpec caseStudySpec);
        public Agent CreateAgent(Agent agent);
        public Agent GetAgentById(int? id);
        public Agent RemovePhoto(int? id);
        public void UpdateAgent(Agent agentToUpdate, Agent agent);
        public void DeleteAgent(Agent agent);
    }
}
