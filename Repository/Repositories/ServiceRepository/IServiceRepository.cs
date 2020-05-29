using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories.ServiceRepository
{
   public interface IServiceRepository
    {
        public IEnumerable<Service> GetServices();
        public IEnumerable<Service> GetAllServices();
        public IEnumerable<ServiceSpec> GetAllServiceSpecs();
        public ServiceSpec CreateServiceSpec(ServiceSpec model);
        public ServiceSpec GetServiceSpecById(int id);
        public Service GetServiceById(int? id);

        public Service CreateService(Service service);

        public Service RemovePhoto(int? id);
        void UpdateService(Service serviceToUpdate, Service service);
        void UpdateServiceSPec(ServiceSpec specToUpdate, ServiceSpec serviceSpec);

        public void DeleteService(Service service);
        public void DeleteServiceSpec(ServiceSpec serviceSpec);
    }
}
