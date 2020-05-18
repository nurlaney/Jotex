using Repository.Data;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories.AboutCompanyRepository
{
    public class AboutCompanyRepository : IAboutCompanyRepository
    {
       private readonly JotexDbContext _context;
       public AboutCompanyRepository(JotexDbContext context)
        {
            _context = context;
        }
        //about sehifesi post
        public IEnumerable<AboutCompany> GetAboutCompany()
        {
            return _context.AboutCompanies.Where(a => a.Status).ToList();
        }

        //about sehifesi banneri
        public IEnumerable<AboutCompanyBanner> GetAboutCompanyBanners()
        {
            return _context.AboutCompanyBanners.Where(b => b.Status).ToList();
        }

        public IEnumerable<AboutCompanyEncourage> GetAboutCompanyEncourages()
        {
            return _context.AboutCompanyEncourages.Where(e => e.Status).ToList();
        }

        //ana sehife fun fact hissesi
        public IEnumerable<AboutCompanyFunFact> GetAboutCompanyFunFacts()
        {
            return _context.AboutCompanyFunFacts.Where(f => f.Status).ToList();
        }

        // about sehifesi agentler siyahisi
        public IEnumerable<Agent> GetAgents()
        {
          return  _context.Agents.Where(a => a.Status).ToList();
        }
    }
}
