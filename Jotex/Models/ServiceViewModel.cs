using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jotex.Models
{
    public class ServiceViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string BottomDesc { get; set; }
        public string BottomText { get; set; }

        public IList<ServiceSpecViewModel> ServiceSpecs { get; set; }
    }
}
