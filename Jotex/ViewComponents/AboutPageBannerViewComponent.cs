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
    public class AboutPageBannerViewComponent : ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly IAboutCompanyRepository _aboutCompanyRepository;

        public AboutPageBannerViewComponent(IMapper mapper,
                                       IAboutCompanyRepository aboutCompanyRepository)
        {
            _mapper = mapper;
            _aboutCompanyRepository = aboutCompanyRepository;
        }

        public IViewComponentResult Invoke()
        {
            var aboutCompanyBannerItems = _aboutCompanyRepository.GetAboutCompanyBanners();
            var model = _mapper.Map<IEnumerable<AboutCompanyBanner>,IEnumerable<AboutCompanyBannerViewModel>> (aboutCompanyBannerItems);

            return View(model);
        }
    }
}
