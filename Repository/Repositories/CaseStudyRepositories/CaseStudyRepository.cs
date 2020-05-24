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
    }
}
