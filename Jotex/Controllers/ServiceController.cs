using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jotex.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Repository.Repositories.ServiceRepository;

namespace Jotex.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IMapper _mapper;

        public ServiceController(IServiceRepository serviceRepository,
                                 IMapper mapper)
        {
            _serviceRepository = serviceRepository;
            _mapper = mapper;
        }
        public IActionResult Index(int? id)
        {
            var services = _serviceRepository.GetServices();
           
            var model = new ServiceListViewModel
            {
                Services = _mapper.Map<IEnumerable<Service>, IEnumerable<ServiceViewModel>>(services),
            };

            if (id == null)
            {
                model.ActiveService = _mapper.Map<Service, ServiceViewModel>(services.First());
            }
            else
            {
                var active = _serviceRepository.GetServiceById((int)id);

                if (active == null) return NotFound(); 

                model.ActiveService = _mapper.Map<Service, ServiceViewModel>(active);
            }

            return View(model); 
        }
    }
}