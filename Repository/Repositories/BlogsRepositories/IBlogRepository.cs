using Repository.Data;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories.BlogsRepositories
{
    public interface IBlogRepository
    {
        public IEnumerable<Blog> GetBlogs();

        public Blog GetBlogById(int id);

        public int GetBlogCountByServiceId(int serviceId);

        public IEnumerable<Blog> GetRecentBlogs(int take);

        public IEnumerable<Tag> GetTags();

        public Comment CreateComment(Comment comment);

        public IEnumerable<Comment> GetComments();
    }
}
