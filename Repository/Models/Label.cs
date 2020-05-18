using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Models
{
  public  class Label : BaseEntity
    {
        [Required]
        [MaxLength(60)]
        public string Text { get; set; }
        [Required]
        [MaxLength(100)]
        public string Color { get; set; }

        public ICollection<Plan> Plans { get; set; }
    }
}
