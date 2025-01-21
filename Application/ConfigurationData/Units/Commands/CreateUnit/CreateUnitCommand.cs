using ProductionStructure.Application.Abstract;
using ProductionStructure.Domain.Entity.ConfigurationData;
using ProductionStructure.Domain.Entity.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionStructure.Application.ConfigurationData.Units.Commands.CreateWorkSession
{
    public record CreateUnitCommand(string Name, Domain.Entity.ConfigurationData.WorkCenter WorkCenter) : ICommand<Unit>;
}
