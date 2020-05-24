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

        public Service GetServiceById(int id)
        {
            return _context.Services
                                    .Include(s=>s.Blogs)
                                    .Include("ServiceSpecs").FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Service> GetServices()
        {
            return _context.Services.Include(s => s.ServiceSpecs).Where(s => s.Status).ToList();
        }
    }
}
