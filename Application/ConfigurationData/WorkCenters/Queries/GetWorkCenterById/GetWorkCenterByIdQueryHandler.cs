using ProductionStructure.Application.Abstract;
using ProductionStructure.Application.ConfigurationData.WorkCenters.Queries.GetWorkCenterById;
using ProductionStructure.Contracts.ConfigurationData;
using ProductionStructure.Contracts.HistoricalData;
using ProductionStructure.Domain.Entity.ConfigurationData;
using ProductionStructure.Domain.Entity.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionStructure.Application.ConfigurationData.WorkCenters.Queries.GetWorkCenterById
{
    public class GetWorkCenterByIdQueryHandler : IQueryHandler<GetWorkCenterByIdQuery, WorkCenter?>
    {
        private readonly IWorkCenterRepository _workCenterRepository;

        public GetWorkCenterByIdQueryHandler(IWorkCenterRepository workCenterRepository)
        {
            _workCenterRepository = workCenterRepository;
        }

        public Task<WorkCenter?> Handle(GetWorkCenterByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_workCenterRepository.GetWorkCenterById(request.Id));
        }
    }
}

