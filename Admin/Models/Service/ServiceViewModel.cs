using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Models.Service
{
    public class ServiceViewModel
    {

        public bool Status { get; set; }
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(350)]
        public string Title { get; set; }
        [Required]
        [MaxLength(800)]
        public string Text { get; set; }
        [Required]
        [MaxLength(60)]
        public string Logo { get; set; }
        [Required]
        [MaxLength(100)]
        public string Image { get; set; }
    }
}
