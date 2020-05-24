using Microsoft.EntityFrameworkCore;
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
            return _context.AboutCompanies
                                          .Include(a=>a.FunFacts)
                                          .Include(a=>a.Encourages)
                                          .Where(a => a.Status).ToList();
        }

        // about sehifesi agentler siyahisi
        public IEnumerable<Agent> GetAgents()
        {
          return  _context.Agents.Where(a => a.Status).ToList();
        }
    }
}
