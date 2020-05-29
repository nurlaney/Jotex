using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.Filters;
using Admin.Libs;
using Admin.Models.Service;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Data;
using Repository.Models;
using Repository.Repositories.ServiceRepository;
using Repository.Services;

namespace Admin.Controllers
{
    [TypeFilter(typeof(Auth))]
    public class ServiceController : Controller
    {
        private Repository.Models.Admin _admin => RouteData.Values["Admin"] as Repository.Models.Admin;
        private readonly IServiceRepository _serviceRepository;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly IFileManager _fileManager;
        private readonly IMapper _mapper;
        private readonly JotexDbContext _context;

        public ServiceController(IServiceRepository serviceRepository,
                                 IMapper mapper,
                                 ICloudinaryService cloudinaryService,
                                 IFileManager fileManager,
                                 JotexDbContext context)
        {
            _serviceRepository = serviceRepository;
            _mapper = mapper;
            _cloudinaryService = cloudinaryService;
            _fileManager = fileManager;
            _context = context;
        }
        public IActionResult Index()
        {
            var services = _serviceRepository.GetAllServices();
            var model = _mapper.Map<IEnumerable<Service>, IEnumerable<ServiceViewModel>>(services);

            return View(model); 
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ServiceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var service = _mapper.Map<ServiceViewModel, Service>(model);
                service.AddedBy = _admin.Fullname;

                _serviceRepository.CreateService(service);

                return RedirectToAction("index");
            }

            return View(model);
        }
        

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var service = _serviceRepository.GetServiceById(id);
            if (service == null) return NotFound();

            var model = _mapper.Map<Service, ServiceViewModel>(service);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ServiceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var service = _mapper.Map<ServiceViewModel, Service>(model);
                var serviceToUpdate = _serviceRepository.GetServiceById(model.Id);
                if (serviceToUpdate == null) return NotFound(); 
                service.ModifiedBy = _admin.Fullname;
                _serviceRepository.UpdateService(serviceToUpdate, service);

                return RedirectToAction("index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            Service service = _serviceRepository.GetServiceById(id);

            if (service == null) return NotFound();

            _serviceRepository.DeleteService(service);

            return RedirectToAction("index");
        }



        [HttpPost]
        public IActionResult Upload(IFormFile file,int?id)
        {
            var filename = _fileManager.Upload(file);
            var publicId = _cloudinaryService.Store(filename);
            _fileManager.Delete(filename);


            if (id != null)
            {
                var service = _serviceRepository.GetServiceById(id);
                service.Image = publicId;
                _context.SaveChanges();
            }
            

            return Ok(new { 
            filename = publicId,
            src = _cloudinaryService.BuildUrl(publicId)
            });
        } 

        [HttpPost]
        public IActionResult Remove(string name, int? id)
        {
            
                _serviceRepository.RemovePhoto(id);
            

            _cloudinaryService.Delete(name);

            return Ok(new { status = 200 });
        }
    }
}