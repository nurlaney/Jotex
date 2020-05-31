using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.Filters;
using Admin.Libs;
using Admin.Models.Home;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Data;
using Repository.Models;
using Repository.Repositories.SectionRepositories;
using Repository.Services;

namespace Admin.Controllers
{
    [TypeFilter(typeof(Auth))]
    public class SliderItemController : Controller
    {
        private Repository.Models.Admin _admin => RouteData.Values["Admin"] as Repository.Models.Admin;
        private readonly ISectionRepository _sectionRepository;
        private readonly IMapper _mapper;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly IFileManager _fileManager;
        private readonly JotexDbContext _context;

        public SliderItemController(ISectionRepository sectionRepository,
                                   IMapper mapper,
                                   ICloudinaryService cloudinaryService,
                                   IFileManager fileManager,
                                   JotexDbContext context)
        {
            _sectionRepository = sectionRepository;
            _mapper = mapper;
            _cloudinaryService = cloudinaryService;
            _fileManager = fileManager;
            _context = context;
        }
        public IActionResult Index()
        {
            var sliderItem = _sectionRepository.GetAllSliderItems();

            var model = _mapper.Map<IEnumerable<SliderItem>, IEnumerable<SliderItemViewModel>>(sliderItem);


            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SliderItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                var sliderItem = _mapper.Map<SliderItemViewModel, SliderItem>(model);
                sliderItem.AddedBy = _admin.Fullname;
                sliderItem.EndPoint = "#";
                _sectionRepository.CreateSLiderItem(sliderItem);

                return RedirectToAction("index");
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var sliderİtem = _sectionRepository.GetSliderItemById(id);

            var model = _mapper.Map<SliderItem, SliderItemViewModel>(sliderİtem);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SliderItemViewModel model)
        {

            if (ModelState.IsValid)
            {
                var sliderİtem = _mapper.Map<SliderItemViewModel, SliderItem>(model);

                var sliderToUpdate = _sectionRepository.GetSliderItemById(model.Id);

                if (sliderToUpdate == null) return NotFound();

                sliderİtem.ModifiedBy = _admin.Fullname;

                _sectionRepository.UpdateSLiderİtem(sliderToUpdate, sliderİtem);

                return RedirectToAction("index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            SliderItem sliderItem = _sectionRepository.GetSliderItemById(id);

            if (sliderItem == null) return NotFound();

            _sectionRepository.DeleteSLiderItem(sliderItem);

            return RedirectToAction("index");
        }


        [HttpPost]
        public IActionResult Upload(IFormFile file, int? id)
        {
            var filename = _fileManager.Upload(file);
            var publicId = _cloudinaryService.Store(filename);
            _fileManager.Delete(filename);


            if (id != null)
            {
                var sliderItem = _sectionRepository.GetSliderItemById(id);
                sliderItem.Image = publicId;
                _context.SaveChanges();
            }


            return Ok(new
            {
                filename = publicId,
                src = _cloudinaryService.BuildUrl(publicId)
            });
        }

        [HttpPost]
        public IActionResult Remove(string name, int? id)
        {

            _sectionRepository.RemoveSLiderPhoto(id);


            _cloudinaryService.Delete(name);

            return Ok(new { status = 200 });
        }
    }
}