using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jotex.Models
{
    public class ServiceListViewModel
    {
        public ServiceViewModel Service { get; set; }
        public ServiceViewModel ActiveService { get; set; }
        public IEnumerable<ServiceViewModel> Services { get; set; }
    }
}
