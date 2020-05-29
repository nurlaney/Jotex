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

        public  Tag Tag { get; set; }
        public BlogWriter BlogWriter { get; set; }
        public ServiceViewModel Service { get; set; } 
        public IEnumerable<CommentViewModel> Comments { get; set; }
        public CommentViewModel LeaveComment { get; set; }
    }
}
