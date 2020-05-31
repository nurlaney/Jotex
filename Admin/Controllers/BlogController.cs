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
    public class BlogController : Controller
    {
        private Repository.Models.Admin _admin => RouteData.Values["Admin"] as Repository.Models.Admin;
        private readonly IBlogRepository _blogRepository;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly IFileManager _fileManager;
        private readonly IMapper _mapper;
        private readonly JotexDbContext _context;
        private readonly IServiceRepository _serviceRepository;

        public BlogController(IBlogRepository blogRepository,
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
            var blogs = _blogRepository.GetAllBlogs();
            var model = _mapper.Map<IEnumerable<Blog>, IEnumerable<BlogViewModel>>(blogs);

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.services = _serviceRepository.GetAllServices();
            ViewBag.tags = _blogRepository.GetAllTags();
            ViewBag.writers = _blogRepository.GetAllBlogWriters();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BlogViewModel model)
        {
            if (ModelState.IsValid)
            {
                var blog = _mapper.Map<BlogViewModel, Blog>(model);
                blog.AddedBy = _admin.Fullname;

                _blogRepository.CreateBLog(blog);

                return RedirectToAction("index");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.services = _serviceRepository.GetAllServices();
            ViewBag.tags = _blogRepository.GetAllTags();
            ViewBag.writers = _blogRepository.GetAllBlogWriters();

            var blog = _blogRepository.GetAllBLogById(id);
            if (blog == null) return NotFound();

            var model = _mapper.Map<Blog, BlogViewModel>(blog);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BlogViewModel model)
        {
            if (ModelState.IsValid)
            {
                var blog = _mapper.Map<BlogViewModel, Blog>(model);
                var blogToUpdate = _blogRepository.GetAllBLogById(model.Id);
                if (blogToUpdate == null) return NotFound();
                blog.ModifiedBy = _admin.Fullname;

                _blogRepository.UpdateBlog(blogToUpdate, blog);

                return RedirectToAction("index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            Blog blog = _blogRepository.GetAllBLogById(id);

            if (blog == null) return NotFound();

            _blogRepository.DeleteBlog(blog);

            return RedirectToAction("index");
        }



        //================Tags==============
        public IActionResult TagTable()
        {
            var tags = _blogRepository.GetAllTags();
            var model = _mapper.Map<IEnumerable<Tag>, IEnumerable<TagViewModel>>(tags);

            return View(model);
        }

        [HttpGet]
        public IActionResult CreateTag()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTag(TagViewModel model)
        {
            if (ModelState.IsValid)
            {
                var tag = _mapper.Map<TagViewModel, Tag>(model);
                tag.AddedBy = _admin.Fullname;

                _blogRepository.CreateTag(tag);

                return RedirectToAction("tagtable");
            }
            return View(model);
        }

        //edit
        [HttpGet]
        public IActionResult EditTag(int id)
        {
            var tag = _blogRepository.GetTagById(id);

            if (tag == null) return NotFound();

            var model = _mapper.Map<Tag, TagViewModel>(tag);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditTag(TagViewModel model)
        {
            if (ModelState.IsValid)
            {
                var tag = _mapper.Map<TagViewModel, Tag>(model);

                var tagToUpdate = _blogRepository.GetTagById(model.Id);

                if (tagToUpdate == null) return NotFound();

                tag.ModifiedBy = _admin.Fullname;

                _blogRepository.UpdateTag(tagToUpdate, tag);

                return RedirectToAction("tagtable");
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
                var blog = _blogRepository.GetAllBLogById(id);
                blog.Image = publicId;
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

            _blogRepository.RemovePhoto(id);


            _cloudinaryService.Delete(name);

            return Ok(new { status = 200 });
        }

        //delete
        public IActionResult DeleteTag(int id)
        {
            Tag tag = _blogRepository.GetTagById(id);

            if (tag == null) return NotFound();

            _blogRepository.DeleteTag(tag);

            return RedirectToAction("tagtable");
        }
    }
}