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
    public class UnitRepository
        : RepositoryBase, IUnitRepository
    {
        public UnitRepository(ApplicationContext context) : base(context)
        {
        }

        public void AddUnit(Unit unit)
        {
            _context.Units.Add(unit);
        }

        public Unit? GetUnitById(Guid id)
        {
            return _context.Units.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<Unit> GetAllUnits()
        {
            return _context.Units.ToList();
        }

        public void UpdateUnit(Unit unit)
        {
            Unit? previousUnit = _context.Units.FirstOrDefault(u => u.Id == unit.Id);
            if(previousUnit != null)
            {
                if (previousUnit.InUse && !unit.InUse) //MarkAsNotInUse
                {
                    _context.WorkSessions.Update(unit.WorkSessions.FirstOrDefault(ws => ws.Id == previousUnit.CurrentWorkSessionId));
                }
                else if (!previousUnit.InUse && unit.InUse)
                {
                    _context.WorkSessions.Add(unit.CurrentWorkSession);
                }
            }
            _context.Units.Update(unit);
        }

        public void DeleteUnit(Unit unit)
        {
            _context.Units.Remove(unit);
        }
    }
}
