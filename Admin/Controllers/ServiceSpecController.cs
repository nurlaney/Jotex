using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.Filters;
using Admin.Models.Service;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Repository.Repositories.ServiceRepository;

namespace Admin.Controllers
{
    [TypeFilter(typeof(Auth))]
    public class ServiceSpecController : Controller
    {
        Repository.Models.Admin _admin => RouteData.Values["Admin"] as Repository.Models.Admin;
        private readonly IServiceRepository _serviceRepository;
        private readonly IMapper _mapper;

        public ServiceSpecController(IServiceRepository serviceRepository,
                                 IMapper mapper)
        {
            _serviceRepository = serviceRepository;
            _mapper = mapper;
        }
        public IActionResult Index() 
        {
            var specs = _serviceRepository.GetAllServiceSpecs();
            var model = _mapper.Map<IEnumerable<ServiceSpec>, IEnumerable<ServiceSpecViewModel>>(specs);

            return View(model);
        }

        public IActionResult Create()
        {
            ViewBag.Services = _serviceRepository.GetAllServices();
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ServiceSpecViewModel model)
        {
            ViewBag.Services = _serviceRepository.GetAllServices();
            if (ModelState.IsValid)
            {
                var serviceSpec = _mapper.Map<ServiceSpecViewModel, ServiceSpec>(model);

                serviceSpec.AddedBy = _admin.Fullname;

                _serviceRepository.CreateServiceSpec(serviceSpec);

                return RedirectToAction("index");
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Services = _serviceRepository.GetAllServices();

            var serviceSpec = _serviceRepository.GetServiceSpecById(id);

            var model = _mapper.Map<ServiceSpec, ServiceSpecViewModel>(serviceSpec);

            return View(model);
        } 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ServiceSpecViewModel model)
        {
            ViewBag.Services = _serviceRepository.GetAllServices();
            if (ModelState.IsValid)
            {
                var serviceSpec = _mapper.Map<ServiceSpecViewModel, ServiceSpec>(model);
                var specToUpdate = _serviceRepository.GetServiceSpecById(model.Id);
                if (specToUpdate == null) return NotFound();
                serviceSpec.ModifiedBy = _admin.Fullname;
                _serviceRepository.UpdateServiceSPec(specToUpdate,serviceSpec);

                return RedirectToAction("index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            ServiceSpec serviceSpec = _serviceRepository.GetServiceSpecById(id);

            _serviceRepository.DeleteServiceSpec(serviceSpec);

            return RedirectToAction("index");
        }
    }
}