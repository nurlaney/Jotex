using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jotex.Models
{
    public class AboutCompanyViewModel
    {

        public string Title { get; set; }
        public string Text { get; set; }
        public string ActionText { get; set; }
        public string LeftTitle { get; set; }
        public string LeftText { get; set; }
        public string Image { get; set; }
        public IEnumerable<AboutEncourageViewModel> Encourages { get; set; }
        public IEnumerable<AboutFunFactViewModel> FunFacts { get; set; }
    }
}
