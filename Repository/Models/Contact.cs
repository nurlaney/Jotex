using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Models
{
  public  class Contact : BaseEntity
    {
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
    }
}
