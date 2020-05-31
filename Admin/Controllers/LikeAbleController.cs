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
    public class LikeAbleController : Controller
    {
        private Repository.Models.Admin _admin => RouteData.Values["Admin"] as Repository.Models.Admin;
        private readonly ISectionRepository _sectionRepository;
        private readonly IMapper _mapper;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly IFileManager _fileManager;
        private readonly JotexDbContext _context;

        public LikeAbleController(ISectionRepository sectionRepository,
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
            var likeAble = _sectionRepository.GetAllLikeableArea();
            var model = _mapper.Map<IEnumerable<LikeableArea>, IEnumerable<LikeableAreaViewModel>>(likeAble);

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var likeAble = _sectionRepository.GetLikeableAreaById(id);
            if (likeAble == null) return NotFound();

            var model = _mapper.Map<LikeableArea, LikeableAreaViewModel>(likeAble);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(LikeableAreaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var likeAble = _mapper.Map<LikeableAreaViewModel, LikeableArea>(model);

                var likeAbleToUpdate = _sectionRepository.GetLikeableAreaById(model.Id);

                if (likeAble == null) return NotFound();

                likeAble.ModifiedBy = _admin.Fullname;

                _sectionRepository.UpdateLikeAble(likeAbleToUpdate, likeAble);

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
                var likeableArea = _sectionRepository.GetLikeableAreaById(id);

                likeableArea.Image = publicId;

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