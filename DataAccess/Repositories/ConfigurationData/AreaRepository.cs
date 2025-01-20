using DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductionStructure.Domain.Entity.ConfigurationData;
using ProductionStructure.DataAccess.Repositories.Common;
using Contracts;

namespace ProductionStructure.DataAccess.Repositories.ConfigurationData
{
    public class AreaRepository
        : RepositoryBase, IAreaRepository
    {
        public AreaRepository(ApplicationContext context) : base(context)
        {
        }

        public void AddArea(Area area)
        {
            _context.Areas.Add(area);
        }

        public void DeleteArea(Area area)
        {
            _context.Areas.Remove(area);
        }

        public Area? GetAreaById(Guid id)
        {
            return _context.Areas.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Area> GetAllAreas()
        {
            return _context.Areas.ToList();
        }

        public void UpdateArea(Area area)
        {
            _context.Areas.Update(area);
        }
    }
}