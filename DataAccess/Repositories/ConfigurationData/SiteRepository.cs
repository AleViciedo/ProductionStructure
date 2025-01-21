using DataAccess.Context;
using ProductionStructure.Contracts.ConfigurationData;
using ProductionStructure.DataAccess.Repositories.Common;
using ProductionStructure.Domain.Entity.ConfigurationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionStructure.DataAccess.Repositories.ConfigurationData
{
    public class SiteRepository
        : RepositoryBase, ISiteRepository
    {
        public SiteRepository(ApplicationContext context)
            : base(context) { }

        public void AddSite(Site site)
        {
            _context.Sites.Add(site);
        }

        public Site? GetSiteById(Guid id)
        {
            return _context.Sites.FirstOrDefault(s => s.Id == id);
        }

        public void DeleteSite(Site site)
        {
            _context.Sites.Remove(site);
        }

        public IEnumerable<Site> GetAllSites()
        {
            return _context.Sites.ToList();
        }
        
        public void UpdateSite(Site site)
        {
            _context.Sites.Update(site);
        }

    }
}