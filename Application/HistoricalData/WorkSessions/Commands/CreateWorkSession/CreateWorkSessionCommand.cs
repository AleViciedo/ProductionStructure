using ProductionStructure.Application.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductionStructure.Domain;
using ProductionStructure.Domain.Entity.HistoricalData;

namespace ProductionStructure.Application.HistoricalData.WorkSessions.Commands.CreateWorkSession
{
    public record CreateWorkSessionCommand(DateTime InitDate) : ICommand<WorkSession>;
}
