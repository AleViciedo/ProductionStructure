using ProductionStructure.Application.Abstract;
using ProductionStructure.Contracts.HistoricalData;
using ProductionStructure.Domain.Entity.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionStructure.Application.HistoricalData.WorkSessions.Queries.GetWorkSessionById
{
    public class GetWorkSessionByIdQueryHandler : IQueryHandler<GetWorkSessionByIdQuery, WorkSession?>
    {
        private readonly IWorkSessionRepository _workSessionRepository;

        public GetWorkSessionByIdQueryHandler(IWorkSessionRepository workSessionRepository)
        {
            _workSessionRepository = workSessionRepository;
        }

        public Task<WorkSession?> Handle(GetWorkSessionByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_workSessionRepository.GetWorkSessionById(request.Id));
        }
    }
}
