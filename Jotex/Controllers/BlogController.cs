using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jotex.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Repository.Repositories.BlogsRepositories;
using Repository.Repositories.ServiceRepository;

namespace Jotex.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IMapper _mapper;

        public BlogController(IBlogRepository blogRepository,
                              IMapper mapper,
                              IServiceRepository serviceRepository)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
            _serviceRepository = serviceRepository;
        }

        public IActionResult Index()
        {
            var blogItems = _blogRepository.GetBlogs();

            var model = _mapper.Map<IEnumerable<Blog>, IEnumerable<BlogViewModel>>(blogItems);

            return View(model);
        }

        public IActionResult Single(int id)
        {
            ViewBag.services = _serviceRepository.GetServices();
            ViewBag.posts = _blogRepository.GetBlogs();
            ViewBag.tags = _blogRepository.GetTags();
            var blog = _blogRepository.GetBlogById(id);
            var model = _mapper.Map<Blog, BlogViewModel>(blog);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Comment(BlogViewModel model)
        {
            if (ModelState.IsValid)
            {
                Comment comment = new Comment
                {
                    AddedBy = "System",
                    ModifiedBy = "System",
                    Status = true,
                    Text = model.LeaveComment.Text,
                    UserName = model.LeaveComment.UserName,
                    UserEmail = model.LeaveComment.UserEmail,
                    AddedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    BlogId=model.LeaveComment.BlogId
                };
                _blogRepository.CreateComment(comment);

                return RedirectToAction("single",new {id = model.LeaveComment.BlogId });
            }


            return RedirectToAction("single", new { id = model.LeaveComment.BlogId });

        }
    }
}