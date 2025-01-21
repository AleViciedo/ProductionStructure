using ProductionStructure.Application.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionStructure.Application.ConfigurationData.WorkCenters.Commands.DeleteWorkCenter
{
    public record DeleteWorkCenterCommand(Guid Id) : ICommand;
}
