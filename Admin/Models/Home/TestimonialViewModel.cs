using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Models.Home
{
    public class TestimonialViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string WriterName { get; set; }
        [Required]
        [MaxLength(60)]
        public string WriterDesc { get; set; }
        [Required]
        [MaxLength(550)]
        public string Text { get; set; }
        public bool Status { get; set; }
        public string AddedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
