using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.Filters;
using Admin.Models.CaseStudy;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Repository.Repositories.CaseStudyRepositories;
using Repository.Repositories.ServiceRepository;

namespace Admin.Controllers
{
    [TypeFilter(typeof(Auth))]
    public class CaseStudyController : Controller
    {
        private Repository.Models.Admin _admin => RouteData.Values["Admin"] as Repository.Models.Admin;
        private readonly ICaseStudyRepository _caseStudyRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IMapper _mapper;

        public CaseStudyController(ICaseStudyRepository caseStudyRepository,
                                   IMapper mapper,
                                   IServiceRepository serviceRepository)
        {
            _caseStudyRepository = caseStudyRepository;
            _mapper = mapper;
            _serviceRepository = serviceRepository;
        }
        public IActionResult Index()
        {
            var studies = _caseStudyRepository.GetAllCaseStudies();
            var model = _mapper.Map < IEnumerable<CaseStudy>, IEnumerable<CaseStudyViewModel>>(studies);

            return View(model);
        }

        public IActionResult Create()
        {
            ViewBag.Services = _serviceRepository.GetAllServices();
            ViewBag.Agents = _caseStudyRepository.GetAllAgents();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CaseStudyViewModel model)
        {
            ViewBag.Services = _serviceRepository.GetAllServices();
            ViewBag.Agents = _caseStudyRepository.GetAllAgents();

            if (ModelState.IsValid)
            {
                var caseStudy = _mapper.Map<CaseStudyViewModel, CaseStudy>(model);

                caseStudy.AddedBy = _admin.Fullname;

                _caseStudyRepository.CreateCaseStudy(caseStudy);

                return RedirectToAction("index");
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Services = _serviceRepository.GetAllServices();
            ViewBag.Agents = _caseStudyRepository.GetAllAgents();

            var caseStudy = _caseStudyRepository.GetAllCaseStudyById(id);

            var model = _mapper.Map<CaseStudy, CaseStudyViewModel>(caseStudy);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CaseStudyViewModel model)
        {
            ViewBag.Services = _serviceRepository.GetAllServices();
            ViewBag.Agents = _caseStudyRepository.GetAllAgents();
            if (ModelState.IsValid)
            {
                var caseStudy = _mapper.Map<CaseStudyViewModel, CaseStudy>(model);

                var caseToUpdate = _caseStudyRepository.GetAllCaseStudyById(model.Id);

                if (caseToUpdate == null) return NotFound();

                caseToUpdate.ModifiedBy = _admin.Fullname;

                _caseStudyRepository.UpdateCase(caseToUpdate, caseStudy);

                return RedirectToAction("index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            CaseStudy caseStudy = _caseStudyRepository.GetAllCaseStudyById(id);

            _caseStudyRepository.DeleteCase(caseStudy);

            return RedirectToAction("index");
        }

        // şərtlər....
        public IActionResult DetailTable()
        {
            var details = _caseStudyRepository.GetAllCaseStudySpecs();
            var model = _mapper.Map<IEnumerable<CaseStudySpec>, IEnumerable<CaseStudySpecViewModel>>(details);

            return View(model);
        }

        public IActionResult CreateDetail()
        {
            ViewBag.CaseStudy = _caseStudyRepository.GetAllCaseStudies();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateDetail(CaseStudySpecViewModel model)
        {
            ViewBag.CaseStudy = _caseStudyRepository.GetAllCaseStudies();
            if (ModelState.IsValid)
            {
                var detail = _mapper.Map<CaseStudySpecViewModel, CaseStudySpec>(model);

                detail.AddedBy = _admin.Fullname;

                _caseStudyRepository.CreateCaseStudySpec(detail);

                return RedirectToAction("detailtable");
            }
            return View(model);
        }

        public IActionResult EditDetail(int id)
        {
            ViewBag.CaseStudy = _caseStudyRepository.GetAllCaseStudies();

            var detail = _caseStudyRepository.GetAllCaseStudySpecsById(id);

            var model = _mapper.Map<CaseStudySpec, CaseStudySpecViewModel>(detail);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditDetail(CaseStudySpecViewModel model)
        {
            ViewBag.CaseStudy = _caseStudyRepository.GetAllCaseStudies();

            if (ModelState.IsValid)
            {
                var detail = _mapper.Map<CaseStudySpecViewModel, CaseStudySpec>(model);
                var detailToUpdate = _caseStudyRepository.GetAllCaseStudySpecsById(model.Id);
                if (detailToUpdate == null) return NotFound();
                detailToUpdate.ModifiedBy = _admin.Fullname;

                _caseStudyRepository.UpdateCaseStudySpec(detailToUpdate, detail);

                return RedirectToAction("detailtable");
            }
            return View(model);
        }

        public IActionResult DeleteDetail(int id)
        {
            CaseStudySpec caseStudySpec = _caseStudyRepository.GetAllCaseStudySpecsById(id);

            _caseStudyRepository.DeleteCaseStudySpec(caseStudySpec);

            return RedirectToAction("detailtable");
        }
    }
}