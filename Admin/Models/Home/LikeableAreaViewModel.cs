using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Models.Home
{
    public class LikeableAreaViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(300)]
        public string Text { get; set; }
        [Required]
        [MaxLength(100)]
        public string Image { get; set; }
        public bool Status { get; set; }
        public string AddedBy { get; set; }
        public string MoifiedBy { get; set; }
    }
}
