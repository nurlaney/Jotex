using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Models.Pages
{
    public class ContactViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Title { get; set; }
        [Required]
        [MaxLength(250)]
        public string Description { get; set; }
        [Required]
        [MaxLength(150)]
        public string FormTitle { get; set; }
        [Required]
        [MaxLength(250)]
        public string FormDescription { get; set; }
        [Required]
        [MaxLength(100)]
        public string FormActionText { get; set; }
        public string AddedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool Status { get; set; }
    }
}
