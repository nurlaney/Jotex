using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jotex.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Repository.Repositories.CaseStudyRepositories;

namespace Jotex.Controllers
{
    public class CaseStudiesController : Controller
    {
        private readonly ICaseStudyRepository _caseStudyRepository;
        private readonly IMapper _mapper;

       public CaseStudiesController(ICaseStudyRepository caseStudyRepository,
                                    IMapper mapper)
        {
            _caseStudyRepository = caseStudyRepository;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var caseStudies = _caseStudyRepository.GetCaseStudies();

            var model = _mapper.Map<IEnumerable<CaseStudy>, IEnumerable<CaseStudyViewModel>>(caseStudies);

            return View(model);
        }
        public IActionResult Single(int id)
        {
            var caseStudy = _caseStudyRepository.GetCaseStudyById(id);

            if (caseStudy == null) return NotFound();

            var model = _mapper.Map<CaseStudy, CaseStudyViewModel>(caseStudy);

            var relatedCases = _caseStudyRepository.GetCaseStudiesByServiceId(caseStudy.ServiceId, 5);

            ViewBag.relatedCases = _mapper.Map<IEnumerable<CaseStudy>, IEnumerable<CaseStudyViewModel>>(relatedCases);

            return View(model);

        }
    }
}