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

        public Comment CreateComment(Comment comment);

        public IEnumerable<Tag> GetTags();
        public IEnumerable<Blog> GetAllBlogs();
        public Blog GetAllBLogById(int? id);
        public Blog RemovePhoto(int? id);
        public IEnumerable<Tag> GetAllTags();
        public IEnumerable<BlogWriter> GetAllBlogWriters();
        public Tag GetTagById(int id);
        public BlogWriter GetBlogWriterById(int? id);
        public Blog CreateBLog(Blog model);
        public void UpdateBlog(Blog blogToUpdate, Blog blog);
        public void DeleteBlog(Blog blog);
        public Tag CreateTag(Tag model);
        public void UpdateTag(Tag tagToUpdate, Tag tag);
        public void DeleteTag(Tag tag);
        public BlogWriter RemoveWriterPhoto(int? id);
        public BlogWriter CreateBLogWriter(BlogWriter model);
        public void UpdateBlogWriter(BlogWriter writerToUpdate, BlogWriter blogWriter);
        public void DeleteBlogWriter(BlogWriter blogWriter);

      
    }
}
