using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Models.Blog
{
    public class BlogWriterViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(60)] 
        public string Name { get; set; }
        [Required]
        [MaxLength(350)]
        public string Description { get; set; }
        [Required]
        [MaxLength(60)]
        public string Image { get; set; }
        public string AddedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool Status { get; set; }

        public ICollection<BlogViewModel> Blogs { get; set; }
    }
}
