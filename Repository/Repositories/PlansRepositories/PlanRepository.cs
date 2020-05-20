using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories.PlansRepositories
{
    public class PlanRepository : IPlanRepository
    {
        private readonly JotexDbContext _context;
        public PlanRepository(JotexDbContext context)
        {
            _context = context;
        }

        public Plan GetPlanById(int? id)
        {
            return _context.Plans.Include(p => p.Details).Include(p => p.Label).FirstOrDefault(p => p.Status && p.Id == id);
        }

        public IEnumerable<Plan> GetPlans()
        {
            return _context.Plans
                           .Include(p => p.Label)
                           .Include("Details")
                           .Where(p => p.Status)
                           .ToList();
        }
    }
}
