using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Models.Service
{
    public class ServiceSpecViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Key { get; set; }
        [Required]
        [MaxLength(200)]
        public string Value { get; set; }
        public string AddedBy { get; set; }
        public string ModifiedBy { get; set; }
        public int ServiceId { get; set; }
        public bool Status { get; set; }
        public ServiceViewModel Service { get; set; }
    }
}
