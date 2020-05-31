using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.Filters;
using Admin.Models.Home;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Repository.Repositories.SectionRepositories;

namespace Admin.Controllers
{
    [TypeFilter(typeof(Auth))] 
    public class TestimonialController : Controller
    {
        private Repository.Models.Admin _admin => RouteData.Values["Admin"] as Repository.Models.Admin;
        private readonly ISectionRepository _sectionRepository;
        private readonly IMapper _mapper;

        public TestimonialController(ISectionRepository sectionRepository,
                                   IMapper mapper)
        {
            _sectionRepository = sectionRepository;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var testimonials = _sectionRepository.GetAllTestimonials();

            var model = _mapper.Map<IEnumerable<Testimonial>, IEnumerable<TestimonialViewModel>>(testimonials);


            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TestimonialViewModel model)
        {
            if (ModelState.IsValid)
            {
                var testimonial = _mapper.Map<TestimonialViewModel, Testimonial>(model);

                testimonial.AddedBy = _admin.Fullname;

                _sectionRepository.CreateTestimonail(testimonial);

                return RedirectToAction("index");
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var testimonial = _sectionRepository.GetTestimonialById(id);

            var model = _mapper.Map<Testimonial, TestimonialViewModel>(testimonial);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TestimonialViewModel model)
        {

            if (ModelState.IsValid)
            {
                var testimonial = _mapper.Map<TestimonialViewModel, Testimonial>(model);
                var testimonialToUpdate = _sectionRepository.GetTestimonialById(model.Id);
                if (testimonialToUpdate == null) return NotFound();

                testimonial.ModifiedBy = _admin.Fullname;

                _sectionRepository.UpdateTestimonial(testimonialToUpdate, testimonial);

                return RedirectToAction("index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            Testimonial testimonial = _sectionRepository.GetTestimonialById(id);

            _sectionRepository.DeleteTestimonial(testimonial);

            return RedirectToAction("index");
        }
    }
}