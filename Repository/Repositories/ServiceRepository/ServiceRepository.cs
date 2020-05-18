using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories.ServiceRepository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly JotexDbContext _context;
        public ServiceRepository(JotexDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Service> GetServices()
        {
            return _context.Services.Where(s => s.Status).ToList();
        }

        public Service GetServiceWithDetails(int id)
        {
            return _context.Services
                           .Include(s => s.ServiceDetails)
                           .Include(s => s.ServiceSpecs)
                           .FirstOrDefault(s => s.Status && s.Id == id);
        }
    }
}
