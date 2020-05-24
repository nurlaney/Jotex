using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories.BlogsRepositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly JotexDbContext _context;

        public BlogRepository(JotexDbContext context)
        {
            _context = context;
        }

        public Comment CreateComment(Comment comment)
        {

            comment.Status = true;
            comment.AddedBy = "system";
            comment.ModifiedBy = "System";
            comment.AddedDate = DateTime.Now;
            comment.ModifiedDate = DateTime.Now;
            comment.BlogId = 1;
            _context.Add(comment);
            _context.SaveChanges();
            return comment;


        }

        public Blog GetBlogById(int id)
        {
            return _context.Blogs
                                 .Include(b => b.BlogWriter)
                                 .Include(b => b.Comments)
                                 .Include(b=>b.Tag)
                                 .Include(b => b.Service)
                                 .Where(b => b.Status)
                                 .FirstOrDefault(b => b.Id == id);
        }

        public int GetBlogCountByServiceId(int serviceId)
        {
            return _context.Blogs.Where(b => b.ServiceId == serviceId).Where(b => b.Status).Count();
        }

        public IEnumerable<Blog> GetBlogs()
        {
            return _context.Blogs
                                 .Include(b=>b.Tag)
                                 .Include(b=>b.Comments)
                                 .Where(b => b.Status)
                                 .OrderByDescending(b => b.AddedDate)
                                 .ToList();
        }

        public IEnumerable<Comment> GetComments()
        {
            return _context.Comments.Where(c => c.Status).ToList();
        }

        public IEnumerable<Blog> GetRecentBlogs(int take)
        {
            return _context.Blogs.Where(b => b.Status).ToList();
        }

        public IEnumerable<Tag> GetTags()
        {
            return _context.Tags.Where(t => t.Status).ToList();
        }
    }
}
