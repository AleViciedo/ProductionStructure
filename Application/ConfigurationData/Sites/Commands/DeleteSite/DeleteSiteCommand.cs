using ProductionStructure.Application.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionStructure.Application.ConfigurationData.Sites.Commands.DeleteWorkCenter
{
    public record DeleteSiteCommand(Guid Id) : ICommand;
}
