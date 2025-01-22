using ProductionStructure.Application.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionStructure.Application.ConfigurationData.Areas.Commands.DeleteArea
{
    public record DeleteAreaCommand(Guid Id) : ICommand;
}
