using AutoMapper;
using Jotex.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Repository.Repositories.PlansRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jotex.ViewComponents
{
    public class PlanViewComponent : ViewComponent
    {
        private readonly IPlanRepository _planRepository;
        private readonly IMapper _mapper;

       public PlanViewComponent(IPlanRepository planRepository,
                                IMapper mapper)
        {
            _planRepository = planRepository;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var planItems = _planRepository.GetPlans();

            //var planDetails = _planRepository.GetPlanById((int)id);
            var model = _mapper.Map<IEnumerable<Plan>, IEnumerable<PlanViewModel>>(planItems);
            
            return View(model);
        }
    }
}
