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
    public class CoveredController : Controller
    {
        private Repository.Models.Admin _admin => RouteData.Values["Admin"] as Repository.Models.Admin;
        private readonly ISectionRepository _sectionRepository;
        private readonly IMapper _mapper;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly IFileManager _fileManager;
        private readonly JotexDbContext _context;

        public CoveredController(ISectionRepository sectionRepository,
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
            var covered = _sectionRepository.GetAllCovereds();

            var model = _mapper.Map<IEnumerable<CoveredContact>, IEnumerable<CoveredContactViewModel>>(covered);


            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var covered = _sectionRepository.GetCoveredById(id);

            var model = _mapper.Map<CoveredContact, CoveredContactViewModel>(covered);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CoveredContactViewModel model)
        {

            if (ModelState.IsValid)
            {
                var covered = _mapper.Map<CoveredContactViewModel, CoveredContact>(model);

                var coveredToUpdate = _sectionRepository.GetCoveredById(model.Id);

                if (coveredToUpdate == null) return NotFound();

                covered.ModifiedBy = _admin.Fullname;

                _sectionRepository.UpdateCovered(coveredToUpdate, covered);

                return RedirectToAction("index");
            }
            return View(model);
        }




        [HttpPost]
        public IActionResult Upload(IFormFile file, int? id)
        {
            var filename = _fileManager.Upload(file);
            var publicId = _cloudinaryService.Store(filename);
            _fileManager.Delete(filename);


            if (id != null)
            {
                var covered = _sectionRepository.GetCoveredById(id);
                covered.Image = publicId;
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

            _sectionRepository.RemovePhoto1(id);


            _cloudinaryService.Delete(name);

            return Ok(new { status = 200 });
        }
    }
}