using DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionStructure.DataAccess.Repositories.Common.Site
{
    /// <summary>
    /// Implementacion del repositorio <see cref="ISitesRepository"/>.
    /// </summary>
    public class SiteRepository
        : RepositoryBase , ISitesRepository
    {
        public SiteRepository(ApplicationContext context)
            : base(context) {}

        public void AddSite(Site site)
        {
            _context.Site.Add(Site);
        }

        public void DeleteSite(Site sitet)
        {
            _context.Site.Remove(site);
        }

        public IEnumerable<T> GetAllSite<T>() where T : Site
        {
            return _context.Set<T>().ToList();
        }

         
    }
}