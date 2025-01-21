using ProductionStructure.Application.Abstract;
using ProductionStructure.Domain.Entity.ConfigurationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionStructure.Application.ConfigurationData.WorkCenters.Commands.CreateWorkSession
{
    public record CreateWorkCenterCommand(string Name, Area Area) : ICommand<Domain.Entity.ConfigurationData.WorkCenter>;
}
