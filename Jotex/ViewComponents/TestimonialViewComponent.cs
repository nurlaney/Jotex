using AutoMapper;
using Jotex.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Repository.Repositories.SectionRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jotex.ViewComponents
{
    public class TestimonialViewComponent : ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly ISectionRepository _sectionRepository;

        public TestimonialViewComponent(IMapper mapper,
                             ISectionRepository sectionRepository)
        {
            _mapper = mapper;
            _sectionRepository = sectionRepository;
        }

        public IViewComponentResult Invoke()
        {
            var testimonialItems = _sectionRepository.GetTestimonials();
            var model = _mapper.Map<IEnumerable<Testimonial>, IEnumerable<TestimonialViewModel>>(testimonialItems);

            return View(model);
        }
    }
}
