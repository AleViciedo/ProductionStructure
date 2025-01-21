using ProductionStructure.Application.Abstract;
using ProductionStructure.Domain.Entity.ConfigurationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionStructure.Application.ConfigurationData.Units.Queries.GetAllUnits
{
    public record GetAllUnitsQuery() : IQuery<IEnumerable<Unit>>;
}
