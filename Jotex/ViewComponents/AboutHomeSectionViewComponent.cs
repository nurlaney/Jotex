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
    public class AboutHomeSectionViewComponent : ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly IAboutCompanyRepository _aboutCompanyRepository;

        public AboutHomeSectionViewComponent(IMapper mapper,
                                       IAboutCompanyRepository aboutCompanyRepository)
        {
            _mapper = mapper;
            _aboutCompanyRepository = aboutCompanyRepository;
        }

        public IViewComponentResult Invoke()
        {
            var aboutSectionItems = _aboutCompanyRepository.GetAboutCompany();
            var model = _mapper.Map<IEnumerable<AboutCompany>, IEnumerable<AboutCompanySectionViewModel>>(aboutSectionItems);

            return View(model);
        }
    }
}
