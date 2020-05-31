using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.Filters;
using Admin.Libs;
using Admin.Models.AboutUs;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Data;
using Repository.Models;
using Repository.Repositories.AboutCompanyRepository;
using Repository.Services;

namespace Admin.Controllers
{
    [TypeFilter(typeof(Auth))]
    public class AboutUsController : Controller
    {
        private Repository.Models.Admin _admin => RouteData.Values["Admin"] as Repository.Models.Admin;
        private readonly IAboutCompanyRepository _aboutCompanyRepository;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly IFileManager _fileManager;
        private readonly IMapper _mapper;
        private readonly JotexDbContext _context;

        public AboutUsController(IAboutCompanyRepository aboutCompanyRepository,
                                 IMapper mapper,
                                 ICloudinaryService cloudinaryService,
                                 IFileManager fileManager,
                                 JotexDbContext context)
        {
            _aboutCompanyRepository = aboutCompanyRepository;
            _mapper = mapper;
            _cloudinaryService = cloudinaryService;
            _fileManager = fileManager;
            _context = context;
        }
        public IActionResult Index()
        {
            var abouts = _aboutCompanyRepository.GetAllAboutCompany();
            var model = _mapper.Map<IEnumerable<AboutCompany>, IEnumerable<AboutCompanyViewModel>>(abouts);

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var about = _aboutCompanyRepository.GetAboutCompanyById(id);
            if (about == null) return NotFound();

            var model = _mapper.Map<AboutCompany, AboutCompanyViewModel>(about);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AboutCompanyViewModel model)
        {
            if (ModelState.IsValid)
            {
                var about = _mapper.Map<AboutCompanyViewModel, AboutCompany>(model);
                var aboutToUpdate = _aboutCompanyRepository.GetAboutCompanyById(model.Id);
                if (aboutToUpdate == null) return NotFound();
                about.ModifiedBy = _admin.Fullname;

                _aboutCompanyRepository.UpateAboutCompany(aboutToUpdate, about);

                return RedirectToAction("index");
            }
            return View(model);
        }

        //===========Fun=Fact==========================================

        public IActionResult FunTable()
        {
            var funs = _aboutCompanyRepository.GetAboutCompanyFunFacts();
            var model = _mapper.Map<IEnumerable<AboutCompanyFunFact>, IEnumerable<AboutCompanyFunFactViewModel>>(funs);

            return View(model);
        }

        public IActionResult CreateFun()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateFun(AboutCompanyFunFactViewModel model)
        {
            if (ModelState.IsValid)
            {
                var fun = _mapper.Map<AboutCompanyFunFactViewModel,AboutCompanyFunFact >(model);
                fun.AddedBy = _admin.Fullname;
                fun.AboutCompanyId = 2;

                _aboutCompanyRepository.CreateAboutCompanyFunFact(fun);

                return RedirectToAction("funtable");
            }

            return View(model);
        }

        public IActionResult EditFun(int id)
        {
            var fun = _aboutCompanyRepository.GetAboutCompanyFunFactById(id);
            if (fun == null) return NotFound();

            var model = _mapper.Map<AboutCompanyFunFact, AboutCompanyFunFactViewModel>(fun);

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditFun(AboutCompanyFunFactViewModel model)
        {
            if (ModelState.IsValid)
            {
                var fun = _mapper.Map<AboutCompanyFunFactViewModel, AboutCompanyFunFact>(model);
                var funToUpdate = _aboutCompanyRepository.GetAboutCompanyFunFactById(model.Id);
                if (funToUpdate == null) return NotFound();
                fun.ModifiedBy = _admin.Fullname;
                fun.AboutCompanyId = 2;

                _aboutCompanyRepository.EditFunFact(funToUpdate, fun);

                return RedirectToAction("funtable");
            }
            return View(model);
        }

        public IActionResult DeleteFun(int id)
        {

            AboutCompanyFunFact fun = _aboutCompanyRepository.GetAboutCompanyFunFactById(id);

            if (fun == null) return NotFound();

            _aboutCompanyRepository.DeleteFun(fun);

            return RedirectToAction("funtable");
        }

        //=============Encourages=================================================

        public IActionResult EncTable()
        {
            var enc = _aboutCompanyRepository.GetAllAboutCompanyEncourages();
            var model = _mapper.Map<IEnumerable<AboutCompanyEncourage>, IEnumerable<AboutCompanyEncourageViewModel>>(enc);

            return View(model);
        }

        public IActionResult CreateEnc()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateEnc(AboutCompanyEncourageViewModel model)
        {
            if (ModelState.IsValid)
            {
                var enc = _mapper.Map<AboutCompanyEncourageViewModel, AboutCompanyEncourage>(model);
                enc.AddedBy = _admin.Fullname;
                enc.AboutCompanyId = 2;

                _aboutCompanyRepository.CreateEnc(enc);

                return RedirectToAction("enctable");
            }

            return View(model);
        }

        public IActionResult EditEnc(int id)
        {
            var enc = _aboutCompanyRepository.GetAboutCompanyEncourageById(id);
            if (enc == null) return NotFound();

            var model = _mapper.Map<AboutCompanyEncourage, AboutCompanyEncourageViewModel>(enc);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditEnc(AboutCompanyEncourageViewModel model)
        {
            if (ModelState.IsValid)
            {
                var enc = _mapper.Map<AboutCompanyEncourageViewModel, AboutCompanyEncourage>(model);
                var encToUpdate = _aboutCompanyRepository.GetAboutCompanyEncourageById(model.Id);
                if (encToUpdate == null) return NotFound();
                enc.ModifiedBy = _admin.Fullname;
                enc.AboutCompanyId = 2;

                _aboutCompanyRepository.UpdateApboutEnc(encToUpdate, enc);

                return RedirectToAction("enctable");
            }
            return View(model);
        }

        public IActionResult DeleteEnc(int id)
        {

            AboutCompanyEncourage enc = _aboutCompanyRepository.GetAboutCompanyEncourageById(id);

            if (enc == null) return NotFound();

            _aboutCompanyRepository.DeleteEnc(enc);

            return RedirectToAction("enctable");
        }


        [HttpPost]
        public IActionResult Upload(IFormFile file, int? id)
        {
            var filename = _fileManager.Upload(file);
            var publicId = _cloudinaryService.Store(filename);
            _fileManager.Delete(filename);


            if (id != null)
            {
                var about = _aboutCompanyRepository.GetAboutCompanyById(id);
                about.Image = publicId;
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

            _aboutCompanyRepository.RemovePhoto(id);


            _cloudinaryService.Delete(name);

            return Ok(new { status = 200 });
        }
    }
}