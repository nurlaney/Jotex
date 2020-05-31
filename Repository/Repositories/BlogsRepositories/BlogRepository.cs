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

        public Blog CreateBLog(Blog model)
        {
            model.AddedDate = DateTime.Now;
            _context.Add(model);
            _context.SaveChanges();

            return model;
        }

        public BlogWriter CreateBLogWriter(BlogWriter model)
        {
            model.AddedDate = DateTime.Now;
            _context.Add(model);
            _context.SaveChanges();

            return model;
        }

        public Comment CreateComment(Comment comment)
        {

            _context.Add(comment);
            _context.SaveChanges();
            return comment;
        }

        public Tag CreateTag(Tag model)
        {
            model.AddedDate = DateTime.Now;
            _context.Add(model);
            _context.SaveChanges();

            return model;
        }

        public void DeleteBlog(Blog blog)
        {
            _context.Remove(blog);
            _context.SaveChanges();
        }

        public void DeleteBlogWriter(BlogWriter blogWriter)
        {
            _context.Remove(blogWriter);
            _context.SaveChanges();
        }

        public void DeleteTag(Tag tag)
        {
            _context.Remove(tag);
            _context.SaveChanges();
        }

        public Blog GetAllBLogById(int? id)
        {
            return _context.Blogs.OrderByDescending(b => b.AddedDate).FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<Blog> GetAllBlogs()
        {
            return _context.Blogs
                .Include(b=>b.BlogWriter)
                .Include(b=>b.Service)
                .Include(b=>b.Tag)
                .OrderByDescending(b => b.AddedDate).ToList();
        }

        public IEnumerable<BlogWriter> GetAllBlogWriters()
        {
            return _context.BlogWriters.Include(b => b.Blogs).OrderByDescending(b => b.AddedDate).ToList();
        }

        public IEnumerable<Tag> GetAllTags()
        {
            return _context.Tags.Include(t => t.Blogs).OrderByDescending(t => t.AddedDate).ToList();
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

        public IEnumerable<Blog> GetBlogs()
        {
            return _context.Blogs
                                 .Include(b=>b.Tag)
                                 .Include(b=>b.Comments)
                                 .Where(b => b.Status)
                                 .OrderByDescending(b => b.AddedDate)
                                 .ToList();
        }

        public BlogWriter GetBlogWriterById(int? id)
        {
            return _context.BlogWriters.Include(b => b.Blogs)
                                       .OrderByDescending(b => b.AddedDate)
                                       .FirstOrDefault(b => b.Id == id);
        }

        public Tag GetTagById(int id)
        {
            return _context.Tags.Include(t => t.Blogs).OrderByDescending(t => t.AddedDate).FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<Tag> GetTags()
        {
            return _context.Tags.Where(t => t.Status).ToList();
        }

        public Blog RemovePhoto(int? id)
        {
            var blog = _context.Blogs.FirstOrDefault(s => s.Id == id);

            blog.Image = null;

            _context.SaveChanges();

            return blog;
        }

        public BlogWriter RemoveWriterPhoto(int? id)
        {
            var writer = _context.BlogWriters.FirstOrDefault(s => s.Id == id);

            writer.Image = null;

            _context.SaveChanges();

            return writer;
        }

        public void UpdateBlog(Blog blogToUpdate, Blog blog)
        {
            blogToUpdate.ModifiedDate = DateTime.Now;
            blogToUpdate.ServiceId = blog.ServiceId;
            blogToUpdate.BlogWriterId = blog.BlogWriterId;
            blogToUpdate.TagId = blog.TagId;
            blogToUpdate.Title = blog.Title;
            blogToUpdate.Text = blog.Text;
            blogToUpdate.Status = blog.Status;

            _context.SaveChanges();
        }

        public void UpdateBlogWriter(BlogWriter writerToUpdate, BlogWriter blogWriter)
        {
            writerToUpdate.ModifiedDate = DateTime.Now;
            writerToUpdate.Status = blogWriter.Status;
            writerToUpdate.Name = blogWriter.Name;
            writerToUpdate.Description = blogWriter.Description;

            _context.SaveChanges();
        }

        public void UpdateTag(Tag tagToUpdate, Tag tag)
        {
            tagToUpdate.ModifiedDate = DateTime.Now;
            tagToUpdate.Status = tag.Status;
            tagToUpdate.Name = tag.Name;

            _context.SaveChanges();
        }
    }
}
