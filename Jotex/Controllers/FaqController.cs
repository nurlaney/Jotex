using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jotex.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Repository.Repositories.SectionRepositories;

namespace Jotex.Controllers
{
    public class FaqController : Controller
    {
        private readonly ISectionRepository _sectionRepository;
        private readonly IMapper _mapper;

        public FaqController(ISectionRepository sectionRepository,
                             IMapper mapper)
        {
            _sectionRepository = sectionRepository;
            _mapper = mapper;
        }
        public IActionResult Index(int? id)
        {
            var faqs = _sectionRepository.GetFaqs();

            var model = _mapper.Map<IEnumerable<Faq>, IEnumerable<FaqViewModel>>(faqs);

            

            if(id == null)
            {
                model.First().ActiveService = _mapper.Map<Faq, FaqViewModel>(faqs.First());
            }
            else
            {
                var activeQuest = _sectionRepository.GetFaqById((int)id);

                if (activeQuest == null) return NotFound();

                model.First().ActiveService = _mapper.Map<Faq, FaqViewModel>(activeQuest);
            }

            return View(model);
        }
    }
}