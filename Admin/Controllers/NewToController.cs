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
    public class NewToController : Controller
    {
        private Repository.Models.Admin _admin => RouteData.Values["Admin"] as Repository.Models.Admin;
        private readonly ISectionRepository _sectionRepository;
        private readonly IMapper _mapper;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly IFileManager _fileManager;
        private readonly JotexDbContext _context;

        public NewToController(ISectionRepository sectionRepository,
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
            var newTo = _sectionRepository.GetAllNewTo();

            var model = _mapper.Map<IEnumerable<NewTo>, IEnumerable<NewToViewModel>>(newTo);


            return View(model);
        }


        public IActionResult Edit(int id)
        {
            var newTo = _sectionRepository.GetNewToById(id);

            var model = _mapper.Map<NewTo, NewToViewModel>(newTo);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(NewToViewModel model)
        {

            if (ModelState.IsValid)
            {
                var newTo = _mapper.Map<NewToViewModel, NewTo>(model);

                var newToUpdate = _sectionRepository.GetNewToById(model.Id);

                if (newToUpdate == null) return NotFound();

                newTo.ModifiedBy = _admin.Fullname;

                _sectionRepository.UpdateNewTo(newToUpdate, newTo);

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
                var newTo = _sectionRepository.GetNewToById(id);
                newTo.Image = publicId;
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

            _sectionRepository.RemovePhoto(id);


            _cloudinaryService.Delete(name);

            return Ok(new { status = 200 });
        }
    }
}