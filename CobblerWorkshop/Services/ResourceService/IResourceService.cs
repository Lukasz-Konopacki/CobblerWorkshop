using CobblerWorkshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobblerWorkshop.Services.ResourceService
{
    public interface IResourceService
    {
        public IEnumerable<Resource> GetResources();
        public bool SaveChanges(IEnumerable<Resource> resources);
    }
}
