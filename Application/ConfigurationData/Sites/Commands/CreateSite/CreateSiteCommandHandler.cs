using ProductionStructure.Application.Abstract;
using ProductionStructure.Contracts;
using ProductionStructure.Contracts.ConfigurationData;
using ProductionStructure.Contracts.HistoricalData;
using ProductionStructure.Domain.Entity.ConfigurationData;
using ProductionStructure.Domain.Entity.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionStructure.Application.ConfigurationData.Sites.Commands.CreateSite
{
    public class CreateSiteCommandHandler : ICommandHandler<CreateSiteCommand, Site>
    {
        private readonly ISiteRepository _siteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateSiteCommandHandler(ISiteRepository siteRepository, IUnitOfWork unitOfWork)
        {
            _siteRepository = siteRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<Site> Handle(CreateSiteCommand request, CancellationToken cancellationToken)
        {
            Site result = new Site(request.Name, request.Location);
            _siteRepository.AddSite(result);
            _unitOfWork.SaveChanges();

            return Task.FromResult(result);
        }
    }
}
