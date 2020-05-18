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
    public class BrandsViewComponent : ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly ISectionRepository _sectionRepository;

        public BrandsViewComponent(IMapper mapper,
                             ISectionRepository sectionRepository)
        {
            _mapper = mapper;
            _sectionRepository = sectionRepository;
        }

        public IViewComponentResult Invoke()
        {
            var brandItems = _sectionRepository.GetBrands();

            var model = _mapper.Map<IEnumerable<Brand>, IEnumerable<BrandViewModel>>(brandItems);

            return View(model);
        }
        
    }
}
