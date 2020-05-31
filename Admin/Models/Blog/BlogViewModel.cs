using Admin.Models.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Models.Blog
{
    public class BlogViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Title { get; set; }
        [Required]
        [MaxLength(6666)]
        public string Text { get; set; }
        [Required]
        [MaxLength(60)]
        public string Image { get; set; }
        public int? TagId { get; set; }
        public int ServiceId { get; set; }
        public int BlogWriterId { get; set; }
        public string AddedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool Status { get; set; }
        public ServiceViewModel Service { get; set; }
        public BlogWriterViewModel BlogWriter { get; set; }
        public TagViewModel Tag { get; set; }
    }
}
