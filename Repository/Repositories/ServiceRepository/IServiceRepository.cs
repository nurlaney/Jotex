using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories.ServiceRepository
{
   public interface IServiceRepository
    {
        public IEnumerable<Service> GetServices();
        public Service GetServiceById(int id);
        public IEnumerable<ServiceDetail> GetServiceDetails();
        public IEnumerable<ServiceSpec> GetServiceSpecs();
    }
}
