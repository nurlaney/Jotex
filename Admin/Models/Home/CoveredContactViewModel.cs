using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Models.Home
{
    public class CoveredContactViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(400)]
        public string Text { get; set; }
        [Required]
        [MaxLength(60)]
        public string ActionText { get; set; }
        [Required]
        [MaxLength(100)]
        public string Image { get; set; }
        public string AddedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool Status { get; set; }
    }
}
