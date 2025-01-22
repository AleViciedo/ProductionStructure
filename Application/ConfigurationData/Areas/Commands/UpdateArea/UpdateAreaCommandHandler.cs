using ProductionStructure.Application.Abstract;
using ProductionStructure.Application.ConfigurationData.Areas.Commands.UpdateArea;
using ProductionStructure.Contracts;
using ProductionStructure.Contracts.ConfigurationData;
using ProductionStructure.Contracts.HistoricalData;
using ProductionStructure.Domain.Entity.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionStructure.Application.ConfigurationData.Areas.Commands.UpdateArea
{
    public class UpdateAreaCommandHandler : ICommandHandler<UpdateAreaCommand>
    {
        private readonly IAreaRepository _areaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAreaCommandHandler(IAreaRepository areaRepository, IUnitOfWork unitOfWork)
        {
            _areaRepository = areaRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(UpdateAreaCommand request, CancellationToken cancellationToken)
        {
            _areaRepository.UpdateArea(request.Area);
            _unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
