using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Models
{
   public class PlanDetail : BaseEntity
    {
        [Required]
        [MaxLength(300)]
        public string Condition { get; set; }
        public int PlanId { get; set; }
        public Plan Plan { get; set; }
    }
}
