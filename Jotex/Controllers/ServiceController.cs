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
        private readonly IMapper _mapper;
        private readonly IServiceRepository _serviceRepository;

        public ServiceController(IMapper mapper,
                                 IServiceRepository serviceRepository)
        {
            _mapper = mapper;
            _serviceRepository = serviceRepository;
        }
        public IActionResult Index()
        {
            return  View();
        }

        public IActionResult SingleService(int id)
        {
            var singleService = _serviceRepository.GetServiceWithDetails(id);
            if (singleService == null) return NotFound();
            var model = _mapper.Map<Service, ServiceViewModel>(singleService);
            return View(model);
        }
    }
}