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
    public class SliderViewComponent : ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly ISectionRepository _sectionRepository;

       public SliderViewComponent(IMapper mapper,
                            ISectionRepository sectionRepository)
        {
            _mapper = mapper;
            _sectionRepository = sectionRepository;
        }

        public IViewComponentResult Invoke()
        {
            var sliderItems = _sectionRepository.GetSliderItems();
            var model = _mapper.Map<IEnumerable<SliderItem>, IEnumerable<SliderItemViewModel>>(sliderItems);

            return View(model);
        }
    }
}
