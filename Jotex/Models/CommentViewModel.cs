using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jotex.Models
{
    public class CommentViewModel
    {
        [Required(ErrorMessage ="Adınızı daxil edin")]
        [MaxLength(50,ErrorMessage ="maksimum 50 char ola bilər")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="şərhinizi daxil edin")]
        [MaxLength(700,ErrorMessage ="maksimum 700 char ola bilər")]
        public string Text { get; set; }
        [MaxLength(70)]
        [DataType(DataType.EmailAddress,ErrorMessage ="düzgün email adresi yazın")]
        public string UserEmail { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
