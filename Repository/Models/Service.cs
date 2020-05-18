﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Models
{
   public class Service : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Logo { get; set; }

        public ICollection<ServiceSpec> ServiceSpecs { get; set; }
        public ICollection<ServiceDetail> ServiceDetails { get; set; }
    }
}
