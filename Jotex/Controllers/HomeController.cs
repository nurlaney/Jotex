using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Jotex.Models;
using Repository.Data;
using AutoMapper;
using Repository.Models;
using Repository.Repositories.PlansRepositories;

namespace Jotex.Controllers
{
    public class HomeController : Controller
    {
        private readonly JotexDbContext _context;
        private readonly IMapper _mapper;
        private readonly IPlanRepository _planRepository;

        public HomeController(JotexDbContext context,
                              IMapper mapper,
                              IPlanRepository planRepository)
        {
            _mapper = mapper;
            _context = context;
            _planRepository = planRepository;
        }

        public IActionResult Index()
        {
            var areaItems = _context.LikeableAreas.Where(a => a.Status).ToList();
            var model = new HomeViewModel
            {
                LikeableArea = _mapper.Map<LikeableArea, LikeAbleViewModel>(areaItems.First())
            };
            return View(model);
        }
        
        public IActionResult Test()
        {
            var plans = _planRepository.GetPlans();
            var model = _mapper.Map<IEnumerable<Plan>,IEnumerable< PlanViewModel >> (plans);

            return Ok(model);
        }
    }
}
