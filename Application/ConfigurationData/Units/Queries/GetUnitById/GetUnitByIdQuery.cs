using ProductionStructure.Application.Abstract;
using ProductionStructure.Domain;
using ProductionStructure.Domain.Entity.ConfigurationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionStructure.Application.ConfigurationData.Units.Queries.GetUnitById
{
    public record GetUnitById(Guid Id) : IQuery<Unit?>;
}
