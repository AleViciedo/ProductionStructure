using Contracts;
using ProductionStructure.Application.Abstract;
using ProductionStructure.Contracts.HistoricalData;
using ProductionStructure.Domain.Entity.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionStructure.Application.HistoricalData.WorkSessions.Queries.GetAllWorkSessions
{
    public class GetAllWorkSessionsQueryHandler : IQueryHandler<GetAllWorkSessionsQuery, IEnumerable<WorkSession>>
    {
        private readonly IWorkSessionRepository _workSessionRepository;

        public GetAllWorkSessionsQueryHandler(IWorkSessionRepository workSessionRepository)
        {
            _workSessionRepository = workSessionRepository;
        }

        public Task<IEnumerable<WorkSession>> Handle(GetAllWorkSessionsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_workSessionRepository.GetAllWorkSessions());
        }
    }
}
