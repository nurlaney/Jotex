using AutoMapper;
using Jotex.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Repository.Repositories.BlogsRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jotex.ViewComponents
{
    public class BlogViewComponent : ViewComponent
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public BlogViewComponent(IBlogRepository blogRepository,
                                 IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var blogs = _blogRepository.GetBlogs();

            var model = _mapper.Map<IEnumerable<Blog>, IEnumerable<BlogViewModel>>(blogs);

            return View(model);
        }
    }
}
