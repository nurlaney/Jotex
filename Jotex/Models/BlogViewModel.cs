using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jotex.Models
{
    public class BlogViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public DateTime AddedDate { get; set; }


        public int Count { get; set; }

        public  TagViewModel Tag { get; set; }
        public BlogWriterViewModel BlogWriter { get; set; }
        public ServiceViewModel Service { get; set; }
        public IEnumerable<ServiceViewModel> Services { get; set; }
        public IEnumerable<TagViewModel> Tags { get; set; }
        public IEnumerable<BlogViewModel> Blogs { get; set; }
        public BlogViewModel Blog { get; set; }
        public  CommentViewModel Comment { get; set; }
        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}
