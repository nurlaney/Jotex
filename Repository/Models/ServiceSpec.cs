using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Models
{
    public class ServiceSpec :BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Key { get; set; }
        [Required]
        [MaxLength(500)]
        public string Value { get; set; }
        public int ServiceId { get; set; }


        public Service Service { get; set; }
    }
}
