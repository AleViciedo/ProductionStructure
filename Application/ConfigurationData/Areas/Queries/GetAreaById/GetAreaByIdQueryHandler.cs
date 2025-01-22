using ProductionStructure.Application.Abstract;
using ProductionStructure.Application.ConfigurationData.Areas.Queries.GetAreaById;
using ProductionStructure.Contracts.ConfigurationData;
using ProductionStructure.Contracts.HistoricalData;
using ProductionStructure.Domain.Entity.ConfigurationData;
using ProductionStructure.Domain.Entity.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionStructure.Application.ConfigurationData.Areas.Queries.GetAreaById
{
    public class GetAreaByIdQueryHandler : IQueryHandler<GetAreaByIdQuery, Area?>
    {
        private readonly IAreaRepository _areaRepository;

        public GetAreaByIdQueryHandler(IAreaRepository areaRepository)
        {
            _areaRepository = areaRepository;
        }

        public Task<Area?> Handle(GetAreaByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_areaRepository.GetAreaById(request.Id));
        }
    }
}
