using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.Filters;
using Admin.Libs;
using Admin.Models.Blog;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Data;
using Repository.Models;
using Repository.Repositories.BlogsRepositories;
using Repository.Repositories.ServiceRepository;
using Repository.Services;

namespace Admin.Controllers
{
    [TypeFilter(typeof(Auth))]
    public class BlogWriterController : Controller
    {
        private Repository.Models.Admin _admin => RouteData.Values["Admin"] as Repository.Models.Admin;
        private readonly IBlogRepository _blogRepository;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly IFileManager _fileManager;
        private readonly IMapper _mapper;
        private readonly JotexDbContext _context;
        private readonly IServiceRepository _serviceRepository;

        public BlogWriterController(IBlogRepository blogRepository,
                                 IMapper mapper,
                                 ICloudinaryService cloudinaryService,
                                 IFileManager fileManager,
                                 JotexDbContext context,
                                 IServiceRepository serviceRepository)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
            _cloudinaryService = cloudinaryService;
            _fileManager = fileManager;
            _context = context;
            _serviceRepository = serviceRepository;
        }
        public IActionResult Index()
        {
            var writers = _blogRepository.GetAllBlogWriters();
            var model = _mapper.Map<IEnumerable<BlogWriter>, IEnumerable<BlogWriterViewModel>>(writers);

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BlogWriterViewModel model)


        {
            if (ModelState.IsValid)
            {
                var writer = _mapper.Map<BlogWriterViewModel, BlogWriter>(model);

                writer.AddedBy = _admin.Fullname;

                _blogRepository.CreateBLogWriter(writer);

                return RedirectToAction("index");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var writer = _blogRepository.GetBlogWriterById(id);
            if (writer == null) return NotFound();

            var model = _mapper.Map<BlogWriter, BlogWriterViewModel>(writer);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BlogWriterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var blogWriter = _mapper.Map<BlogWriterViewModel, BlogWriter>(model);
                var writerToUpdate = _blogRepository.GetBlogWriterById(model.Id);
                if (writerToUpdate == null) return NotFound();
                writerToUpdate.ModifiedBy = _admin.Fullname;

                _blogRepository.UpdateBlogWriter(writerToUpdate, blogWriter);

                return RedirectToAction("index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            BlogWriter blogWriter = _blogRepository.GetBlogWriterById(id);

            if (blogWriter == null) return NotFound();

            _blogRepository.DeleteBlogWriter(blogWriter);

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
                var writer = _blogRepository.GetBlogWriterById(id);
                writer.Image = publicId;
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

            _blogRepository.RemoveWriterPhoto(id);


            _cloudinaryService.Delete(name);

            return Ok(new { status = 200 });
        }
    }
}