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
    public class BrandController : Controller
    {
        private Repository.Models.Admin _admin => RouteData.Values["Admin"] as Repository.Models.Admin;
        private readonly ISectionRepository _sectionRepository;
        private readonly IMapper _mapper;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly IFileManager _fileManager;
        private readonly JotexDbContext _context;

        public BrandController(ISectionRepository sectionRepository,
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
            var brands = _sectionRepository.GetAllBrands();

            var model = _mapper.Map<IEnumerable<Brand>, IEnumerable<BrandViewModel>>(brands);


            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BrandViewModel model)
        {
            if (ModelState.IsValid)
            {
                var brand = _mapper.Map<BrandViewModel, Brand>(model);
                brand.AddedBy = _admin.Fullname;

                _sectionRepository.CreateBrand(brand);

                return RedirectToAction("index");
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var brand = _sectionRepository.GetBrandById(id);

            var model = _mapper.Map<Brand, BrandViewModel>(brand);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BrandViewModel model)
        {

            if (ModelState.IsValid)
            {
                var brand = _mapper.Map<BrandViewModel, Brand>(model);

                var brandToUpdate = _sectionRepository.GetBrandById(model.Id);

                if (brandToUpdate == null) return NotFound();

                brand.ModifiedBy = _admin.Fullname;

                _sectionRepository.UpdateBrand(brandToUpdate, brand);

                return RedirectToAction("index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            Brand brand = _sectionRepository.GetBrandById(id);

            if (brand == null) return NotFound();

            _sectionRepository.DeleteBrand(brand);

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
                var brand = _sectionRepository.GetBrandById(id);
                brand.Logo = publicId;
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

            _sectionRepository.RemoveBrandPhoto(id);


            _cloudinaryService.Delete(name);

            return Ok(new { status = 200 });
        }
    }
}