using ProductionStructure.Application.Abstract;
using ProductionStructure.Application.ConfigurationData.Sites.Queries.GetSiteById;
using ProductionStructure.Contracts.ConfigurationData;
using ProductionStructure.Contracts.HistoricalData;
using ProductionStructure.Domain.Entity.ConfigurationData;
using ProductionStructure.Domain.Entity.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionStructure.Application.ConfigurationData.Sites.Queries.GetSiteById
{
    public class GetSiteByIdQueryHandler : IQueryHandler<GetSiteByIdQuery, Site?>
    {
        private readonly ISiteRepository _siteRepository;

        public GetSiteByIdQueryHandler(ISiteRepository siteRepository)
        {
            _siteRepository = siteRepository;
        }

        public Task<Site?> Handle(GetSiteByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_siteRepository.GetSiteById(request.Id));
        }
    }
}
