using AutoMapper;
using Jotex.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Repository.Repositories.AboutCompanyRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jotex.ViewComponents
{
    public class AgentViewComponent : ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly IAboutCompanyRepository _aboutCompanyRepository;

        public AgentViewComponent(IMapper mapper,
                                       IAboutCompanyRepository aboutCompanyRepository)
        {
            _mapper = mapper;
            _aboutCompanyRepository = aboutCompanyRepository;
        }

        public IViewComponentResult Invoke()
        {
            var agents = _aboutCompanyRepository.GetAgents();
            var model = _mapper.Map<IEnumerable<Agent>, IEnumerable<AgentViewModel>>(agents);

            return View(model);
        }
    }
}
