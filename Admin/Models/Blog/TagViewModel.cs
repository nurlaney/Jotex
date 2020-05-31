using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Models.Blog
{
    public class TagViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(60)]
        public string Name { get; set; }
        public string AddedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool Status { get; set; }
        public ICollection<BlogViewModel> Blogs { get; set; }
    }
}
