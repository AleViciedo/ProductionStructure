using DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity.ConfigurationData;

namespace ProductionStructure.DataAccess.Repositories.Common.Area
{
     /// <summary>
    /// Implementación del repositorio <see cref="IAreaRepository"/>.
    /// </summary>
    public class AreaRepository
        : RepositoryBase, IAreaRepository, SiteRepository
    {
        public AreaRepository(ApplicationContext context) : base(context);
        {}

        public void AddArea(Area area)
        {
            _context.Area.Add(area);
        }

        public void DeleteArea (Area area)
        {
            _context.Area.Remove(area);
        }

        public IEnumerable<Area> GetAllArea()
        {
            return _context.Area.ToList();
        }

        public void UpdateArea(Area area)
        {
            _context.Area.Update(area);
        }
    }
}