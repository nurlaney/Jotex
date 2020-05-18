using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Models
{
   public class Plan : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(100)]
        public string Icon { get; set; }
        [Required]
        [MaxLength(100)]
        public string Condition { get; set; }
        [Required]
        [MaxLength(60)]
        public string ActionText { get; set; }
        public int LabelId { get; set; }

        public Label Label { get; set; }
    }
}
