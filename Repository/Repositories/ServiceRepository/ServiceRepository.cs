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

        public Service CreateService(Service service)
        {
            service.AddedDate = DateTime.Now;
            _context.Add(service);
            _context.SaveChanges();

            return service;
        }

        public ServiceSpec CreateServiceSpec(ServiceSpec model)
        {
            model.AddedDate = DateTime.Now;
            _context.Add(model);
            _context.SaveChanges(); 

            return model;
        }

        public void DeleteService(Service service)
        {
            _context.Services.Remove(service);

            _context.SaveChanges();
        }

        public void DeleteServiceSpec(ServiceSpec serviceSpec)
        {
            _context.ServiceSpecs.Remove(serviceSpec);
            _context.SaveChanges();
        }

        public IEnumerable<Service> GetAllServices()
        {
            return _context.Services.OrderByDescending(s => s.AddedDate).ToList();
        }

        public IEnumerable<ServiceSpec> GetAllServiceSpecs()
        {
            return _context.ServiceSpecs
                                        .Include(s=>s.Service)
                                        .OrderByDescending(s => s.AddedDate)
                                        .ToList();
        }

        public Service GetServiceById(int? id)
        {
            return _context.Services
                                    .Include(s=>s.Blogs)
                                    .Include("ServiceSpecs").FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Service> GetServices()
        {
            return _context.Services.Include(s => s.ServiceSpecs).Where(s => s.Status).ToList();
        }

        public ServiceSpec GetServiceSpecById(int id)
        {
            return _context.ServiceSpecs.FirstOrDefault(s => s.Id == id);
        }

        public Service RemovePhoto(int? id)
        {
            var service = _context.Services.FirstOrDefault(s => s.Id == id);

            service.Image = null;

            _context.SaveChanges();

            return service;

        }

        public void UpdateService(Service serviceToUpdate, Service service)
        {
            serviceToUpdate.Status = service.Status;
            serviceToUpdate.Name = service.Name;
            serviceToUpdate.Title = service.Title;
            serviceToUpdate.Text = service.Text;
            serviceToUpdate.Logo = service.Logo;
            serviceToUpdate.ModifiedDate = DateTime.Now;

            _context.SaveChanges();

        }

        public void UpdateServiceSPec(ServiceSpec specToUpdate, ServiceSpec serviceSpec)
        {
            specToUpdate.Status = serviceSpec.Status;
            specToUpdate.ModifiedDate = DateTime.Now;
            specToUpdate.Key = serviceSpec.Key;
            specToUpdate.Value = serviceSpec.Value;
            specToUpdate.ServiceId = serviceSpec.ServiceId;

            _context.SaveChanges();
        }
    }
}
