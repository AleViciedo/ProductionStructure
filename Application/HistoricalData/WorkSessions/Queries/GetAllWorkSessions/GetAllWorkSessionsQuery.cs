using ProductionStructure.Application.Abstract;
using ProductionStructure.Domain.Entity.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionStructure.Application.HistoricalData.WorkSessions.Queries.GetAllWorkSessions
{
    public record GetAllWorkSessionsQuery() : IQuery<IEnumerable<WorkSession>>;
}
