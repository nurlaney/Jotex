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
            return _context.Services.Include("ServiceSpecs").Include("ServiceDetails").FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<ServiceDetail> GetServiceDetails()
        {
           return _context.ServiceDetails.Where(s => s.Status).ToList();
        }

        public IEnumerable<Service> GetServices()
        {
            return _context.Services
                           .Include("ServiceSpecs")
                           .Include("ServiceDetails")
                           .Where(s => s.Status)
                           .ToList();
        }

        public IEnumerable<ServiceSpec> GetServiceSpecs()
        {
            return _context.ServiceSpecs.Where(s => s.Status).ToList();
        }
    }
}
