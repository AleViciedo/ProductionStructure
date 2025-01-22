using ProductionStructure.Application.Abstract;
using ProductionStructure.Application.ConfigurationData.Sites.Commands.UpdateSite;
using ProductionStructure.Contracts;
using ProductionStructure.Contracts.ConfigurationData;
using ProductionStructure.Contracts.HistoricalData;
using ProductionStructure.Domain.Entity.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionStructure.Application.ConfigurationData.Sites.Commands.UpdateSite
{
    public class UpdateSiteCommandHandler : ICommandHandler<UpdateSiteCommand>
    {
        private readonly ISiteRepository _siteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateSiteCommandHandler(ISiteRepository siteRepository, IUnitOfWork unitOfWork)
        {
            _siteRepository = siteRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(UpdateSiteCommand request, CancellationToken cancellationToken)
        {
            _siteRepository.UpdateSite(request.Site);
            _unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
