using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jotex.Models
{
    public class ServiceViewModel
    {
        public IList<ServiceSpecViewModel> ServiceSpecs { get; set; }
        public IList<ServiceDetailViewModel> ServiceDetails { get; set; }
        public IList<ServiceListViewModel> ServiceLists{ get; set; }
    }
}
