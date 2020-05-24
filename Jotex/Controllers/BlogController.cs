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
            var blog = _blogRepository.GetBlogById(id);
            var blogs = _blogRepository.GetBlogs();

            var services = _serviceRepository.GetServices();

            var service = _serviceRepository.GetServiceById(blog.ServiceId);

            var tags = _blogRepository.GetTags();

            var blogCount = _blogRepository.GetBlogCountByServiceId(service.Id);

            var comment = _blogRepository.GetComments();

            var model = new BlogViewModel
            {
                Services = _mapper.Map<IEnumerable<Service>, IEnumerable<ServiceViewModel>>(services),
                Blogs = _mapper.Map<IEnumerable<Blog>, IEnumerable<BlogViewModel>>(blogs),
                Tags = _mapper.Map<IEnumerable<Tag>, IEnumerable<TagViewModel>>(tags),
                Blog = _mapper.Map<Blog,BlogViewModel>(blog),
                Count = blogCount,
                Service = _mapper.Map<Service,ServiceViewModel>(service),
                Comments = _mapper.Map<IEnumerable<Comment>,IEnumerable<CommentViewModel>>(comment)
            };
            

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Comment(CommentViewModel comment)
        {

            if (ModelState.IsValid)
            {
                var model = _mapper.Map<CommentViewModel, Comment>(comment);
                _blogRepository.CreateComment(model);
                return RedirectToAction("single", "blog");
            }
            return View("~/Views/Blog/Single.cshtml",new BlogViewModel());
           
        }
    }
}