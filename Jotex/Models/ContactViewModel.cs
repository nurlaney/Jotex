using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jotex.Models
{
    public class ContactViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string FormTitle { get; set; }
        public string FormDescription { get; set; }
        public string FormActionText { get; set; }

        public IEnumerable<SettingViewModel> Settings { get; set; }
    }
}
