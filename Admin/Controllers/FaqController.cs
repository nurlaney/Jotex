using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.Filters;
using Admin.Models.Pages;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Repository.Repositories.SectionRepositories;

namespace Admin.Controllers
{
    [TypeFilter(typeof(Auth))]
    public class FaqController : Controller
    {
        private Repository.Models.Admin _admin => RouteData.Values["Admin"] as Repository.Models.Admin;
        private readonly IMapper _mapper;
        private readonly ISectionRepository _sectionRepository;
        public FaqController(IMapper mapper,
            ISectionRepository sectionRepository)
        {
            _mapper = mapper;
            _sectionRepository = sectionRepository;
        }
        public IActionResult Index()
        {
            var faqs = _sectionRepository.GetAllFaqs();
            var model = _mapper.Map<IEnumerable<Faq>, IEnumerable<FaqViewModel>>(faqs);

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FaqViewModel model)
        {
            if (ModelState.IsValid)
            {
                Faq faq = _mapper.Map<FaqViewModel, Faq>(model);
                model.AddedBy = _admin.Fullname;

                _sectionRepository.CreateFaq(faq);
                return RedirectToAction("index");
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            Faq faq = _sectionRepository.GetFaqById(id);

            if (faq == null) return NotFound();

            var model = _mapper.Map<Faq, FaqViewModel>(faq);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(FaqViewModel model)
        {

            if (ModelState.IsValid)
            {
                var faq = _mapper.Map<FaqViewModel, Faq>(model);
                var faqToUpdate = _sectionRepository.GetFaqById(model.Id);

                if (faqToUpdate == null) return NotFound();

                faq.ModifiedBy = _admin.Fullname;

                _sectionRepository.UpdateFaq(faqToUpdate, faq);

                return RedirectToAction("index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            Faq faq = _sectionRepository.GetFaqById(id);

            _sectionRepository.DeleteFaq(faq);

            return RedirectToAction("index");
        }
    }
}