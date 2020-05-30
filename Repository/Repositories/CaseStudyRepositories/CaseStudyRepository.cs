using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories.CaseStudyRepositories
{
    public class CaseStudyRepository : ICaseStudyRepository
    {
        private readonly JotexDbContext _context;
        public CaseStudyRepository(JotexDbContext context)
        {
            _context = context;
        }

        public CaseStudy CreateCaseStudy(CaseStudy model)
        {
            model.AddedDate = DateTime.Now;
            _context.Add(model);
            _context.SaveChanges();

            return model;
        }

        public CaseStudySpec CreateCaseStudySpec(CaseStudySpec model)
        {
            model.AddedDate = DateTime.Now;
            _context.Add(model);
            _context.SaveChanges();

            return model;
        }

        public void DeleteCase(CaseStudy caseStudy)
        {
            _context.Remove(caseStudy);
            _context.SaveChanges();
        }

        public void DeleteCaseStudySpec(CaseStudySpec caseStudySpec)
        {
            _context.Remove(caseStudySpec);
            _context.SaveChanges();
        }

        public IEnumerable<Agent> GetAllAgents()
        {
            return _context.Agents.OrderByDescending(a => a.AddedDate).ToList();
        }

        public IEnumerable<CaseStudy> GetAllCaseStudies()
        {
            return _context.CaseStudies
                .Include(c => c.Agent)
                .Include(c => c.Service)
                .Include(c => c.CaseStudySpecs)
                .OrderByDescending(c => c.AddedDate)
                .ToList();
        }

        public CaseStudy GetAllCaseStudyById(int id)
        {
            return _context.CaseStudies.Include(c => c.CaseStudySpecs)
                                       .Include(c => c.Agent)
                                       .Include(c => c.Service)
                                       .FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<CaseStudySpec> GetAllCaseStudySpecs()
        {
            return _context.CaseStudySpecs
                                           .Include(c=>c.CaseStudy)
                                            .OrderByDescending(c => c.AddedDate).ToList();
        }

        public CaseStudySpec GetAllCaseStudySpecsById(int id)
        {
            return _context.CaseStudySpecs
                .Include(c => c.CaseStudy)
                .OrderByDescending(c => c.AddedDate)
                .FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<CaseStudy> GetCaseStudies()
        {
            return _context.CaseStudies
                                       .Include(c=>c.Agent)
                                       .Include(c=>c.Service)
                                       .Where(c => c.Status).ToList();
        }

        public IEnumerable<CaseStudy> GetCaseStudiesByServiceId(int serviceId, int take)
        {
            return _context.CaseStudies
                                       .Include(c => c.CaseStudySpecs)
                                       .Include(c => c.Service)
                                       .Include(c => c.Agent)
                                       .Where(c => c.Status)
                                       .Where(c => c.ServiceId == serviceId);
        }

        public CaseStudy GetCaseStudyById(int id)
        {
            return _context.CaseStudies
                                       .Include(c => c.CaseStudySpecs)
                                       .Include(c=>c.Agent)
                                       .Include(c=>c.Service)
                                       .Where(c => c.Status)
                                       .FirstOrDefault(c => c.Id == id);
        }

        public void UpdateCase(CaseStudy caseToUpdate, CaseStudy caseStudy)
        {
            caseToUpdate.ModifiedDate = DateTime.Now;
            caseToUpdate.ServiceId = caseStudy.ServiceId;
            caseToUpdate.AgentId = caseStudy.AgentId;
            caseToUpdate.Name = caseStudy.Name;
            caseToUpdate.Title = caseStudy.Title;
            caseToUpdate.Status = caseStudy.Status;
            caseToUpdate.Description = caseStudy.Description;
            caseToUpdate.Text = caseStudy.Text;
            caseToUpdate.Challenge = caseStudy.Challenge;
            caseToUpdate.Solution = caseStudy.Solution;
            caseToUpdate.Results = caseStudy.Results;

            _context.SaveChanges();
        }

        public void UpdateCaseStudySpec(CaseStudySpec detailToUpdate, CaseStudySpec caseStudySpec)
        {
            detailToUpdate.Status = caseStudySpec.Status;
            detailToUpdate.ModifiedDate = DateTime.Now;
            detailToUpdate.Key = caseStudySpec.Key;
            detailToUpdate.Value = caseStudySpec.Value;
            detailToUpdate.CaseStudyId = caseStudySpec.CaseStudyId;

            _context.SaveChanges();
        }
    }
}
