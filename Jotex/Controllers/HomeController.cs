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
using Repository.Repositories.SectionRepositories;

namespace Jotex.Controllers
{
    public class HomeController : Controller
    {
        private readonly JotexDbContext _context;
        private readonly IMapper _mapper;
        private readonly ISectionRepository _sectionRepository;
        

        public HomeController(JotexDbContext context,
                              IMapper mapper,
                              ISectionRepository sectionRepository)
        {
            _mapper = mapper;
            _context = context;
            _sectionRepository = sectionRepository;
        }

        public IActionResult Index()
        {
            var contactSectionItems = _sectionRepository.GetSectionItems();
            var areaItems = _sectionRepository.GetLikeableAreas();
            var newToItems = _sectionRepository.GetNewTo();

            var model = new HomeViewModel
            {
                ContactSection = _mapper.Map<CoveredContact, ContactSectionViewModel>(contactSectionItems.First()),

                LikeableArea = _mapper.Map<LikeableArea,LikeAbleViewModel>(areaItems.First()),

                NewTo = _mapper.Map<NewTo, NewToViewModel>(newToItems.First())
            };
            return View(model);
        }
    }
}
