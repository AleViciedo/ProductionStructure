using Contracts;
using ProductionStructure.Application.Abstract;
using ProductionStructure.Application.ConfigurationData.Sites.Commands.DeleteWorkCenter;
using ProductionStructure.Contracts.ConfigurationData;
using ProductionStructure.Contracts.HistoricalData;
using ProductionStructure.Domain.Entity.ConfigurationData;
using ProductionStructure.Domain.Entity.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionStructure.Application.ConfigurationData.Sites.Commands.DeleteSite
{
    public class DeleteSiteCommandHandler : ICommandHandler<DeleteSiteCommand>
    {
        private readonly ISiteRepository _siteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSiteCommandHandler(ISiteRepository siteRepository, IUnitOfWork unitOfWork)
        {
            _siteRepository = siteRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(DeleteSiteCommand request, CancellationToken cancellationToken)
        {
            Site? site = _siteRepository.GetSiteById(request.Id);
            if (site is null)
            {
                return Task.CompletedTask;
            }
            _siteRepository.DeleteSite(site);
            _unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
