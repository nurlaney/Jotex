using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories.ServiceRepository
{
   public interface IServiceRepository
    {
        public Service GetServiceWithDetails(int id);
      public IEnumerable<Service> GetServices();
    }
}
