using ProductionStructure.Application.Abstract;
using ProductionStructure.Application.ConfigurationData.Units.Queries.GetUnitById;
using ProductionStructure.Contracts.ConfigurationData;
using ProductionStructure.Contracts.HistoricalData;
using ProductionStructure.Domain.Entity.ConfigurationData;
using ProductionStructure.Domain.Entity.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionStructure.Application.ConfigurationData.Units.Queries.GetUnitById
{
    public class GetUnitByIdQueryHandler : IQueryHandler<GetUnitByIdQuery, Unit?>
    {
        private readonly IUnitRepository _unitRepository;

        public GetUnitByIdQueryHandler(IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;
        }

        public Task<Unit?> Handle(GetUnitByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_unitRepository.GetUnitById(request.Id));
        }
    }
}
