using Contracts;
using ProductionStructure.Application.Abstract;
using ProductionStructure.Application.ConfigurationData.Areas.Commands.DeleteWorkCenter;
using ProductionStructure.Contracts.HistoricalData;
using ProductionStructure.Domain.Entity.ConfigurationData;
using ProductionStructure.Domain.Entity.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionStructure.Application.ConfigurationData.Areas.Commands.DeleteArea
{
    public class DeleteAreaCommandHandler : ICommandHandler<DeleteAreaCommand>
    {
        private readonly IAreaRepository _areaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAreaCommandHandler(IAreaRepository areaRepository, IUnitOfWork unitOfWork)
        {
            _areaRepository = areaRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(DeleteAreaCommand request, CancellationToken cancellationToken)
        {
            Area? area = _areaRepository.GetAreaById(request.Id);
            if (area is null)
            {
                return Task.CompletedTask;
            }
            _areaRepository.DeleteArea(area);
            _unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
