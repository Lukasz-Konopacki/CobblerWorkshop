using CobblerWorkshop.DbProviders;
using CobblerWorkshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobblerWorkshop.Services.ResourceService
{
    public class ResourceService : IResourceService
    {
        private readonly SqliteDbContext _context;

        public ResourceService(SqliteDbContext databaseContext)
        {
            _context = databaseContext;
        }

        public IEnumerable<Resource> GetResources()
        {
            return _context.Resources.ToList();   
        }

        public bool SaveChanges(IEnumerable<Resource> resources)
        {
            var maxId = resources.Max(x => x.Id);
            var maxIdDb = _context.Resources.Count() > 0 ? _context.Resources.Max(x => x.Id) : 0;
            var dbResources = _context.Resources.AsEnumerable();

            var toAdd = resources.Where(r => r.Id == 0).ToList();
            var toDelete = dbResources.Where(r => !resources.Any(res => res.Id == r.Id)).ToList();
            var toUpdate = dbResources.Where(r => resources.Any(res => res.Id == r.Id)).ToList();

            _context.Resources.RemoveRange(toDelete);
            _context.Resources.AddRange(toAdd);
            foreach (var dbResource in toUpdate)
            {
                var updatedResource = resources.First(r => r.Id == dbResource.Id);
                dbResource.Name = updatedResource.Name;
            }

            _context.SaveChanges();

            return true;
        }
    }
}
