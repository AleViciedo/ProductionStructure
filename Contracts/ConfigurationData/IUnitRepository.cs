using ProductionStructure.Domain.Entity.ConfigurationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionStructure.Contracts.ConfigurationData
{
    public interface IUnitRepository
    {
        void AddUnit(Unit unit);

        Unit? GetUnitById(Guid id);

        public IEnumerable<Unit> GetAllUnits();

        void UpdateUnit(Unit unit);

        void DeleteUnit(Unit unit);
    }
}
