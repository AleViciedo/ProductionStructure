using ProductionStructure.Application.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductionStructure.Domain;
using ProductionStructure.Domain.Entity.HistoricalData;
using ProductionStructure.Domain.Entity.ConfigurationData;

namespace ProductionStructure.Application.HistoricalData.WorkSessions.Commands.CreateWorkSession
{
    public record CreateWorkSessionCommand(DateTime InitDate, Unit Unit) : ICommand<WorkSession>;
}
