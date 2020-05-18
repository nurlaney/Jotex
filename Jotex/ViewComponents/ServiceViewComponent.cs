using AutoMapper;
using Jotex.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Repository.Repositories.AboutCompanyRepository;
using Repository.Repositories.ServiceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jotex.ViewComponents
{
    public class ServiceViewComponent : ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly IServiceRepository _serviceRepository;

        public ServiceViewComponent(IMapper mapper,
                                    IServiceRepository serviceRepository)
        {
            _mapper = mapper;
            _serviceRepository = serviceRepository;
        }

        public IViewComponentResult Invoke()
        {
            var serviceItems = _serviceRepository.GetServices();
            var model = _mapper.Map<IEnumerable<Service>, IEnumerable<ServiceListViewModel>>(serviceItems);

            return View(model);
        }
    }
}
