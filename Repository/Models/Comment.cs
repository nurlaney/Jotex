using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Models
{
   public class Comment : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(700)]
        public string Text { get; set; }
        [MaxLength(70)]
        [DataType(DataType.EmailAddress)]
        public string UserEmail { get; set; }
        public int BlogId { get; set; }


        public Blog Blog { get; set; }
    }
}
