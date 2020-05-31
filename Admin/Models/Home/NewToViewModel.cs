using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Models.Home
{
    public class NewToViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(250)]
        public string Text { get; set; }
        [Required]
        [MaxLength(100)]
        public string Entry { get; set; }
        [Required]
        [MaxLength(100)]
        public string Image { get; set; }
        [Required]
        [MaxLength(190)]
        public string ImageText { get; set; }
        public string ModifiedBy { get; set; }
        public bool Status { get; set; }
    }
}
