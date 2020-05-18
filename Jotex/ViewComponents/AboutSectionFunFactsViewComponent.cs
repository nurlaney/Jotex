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
    public class AboutSectionFunFactsViewComponent : ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly IAboutCompanyRepository _aboutCompanyRepository;

        public AboutSectionFunFactsViewComponent(IMapper mapper,
                                       IAboutCompanyRepository aboutCompanyRepository)
        {
            _mapper = mapper;
            _aboutCompanyRepository = aboutCompanyRepository;
        }

        public IViewComponentResult Invoke()
        {
            var funFacts = _aboutCompanyRepository.GetAboutCompanyFunFacts();
            var model = _mapper.Map<IEnumerable<AboutCompanyFunFact>, IEnumerable<AboutSectionFunFactViewModel>>(funFacts);

            return View(model);
        }
    }
}
