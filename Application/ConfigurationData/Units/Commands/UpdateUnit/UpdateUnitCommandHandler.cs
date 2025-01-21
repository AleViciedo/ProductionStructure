using Contracts;
using ProductionStructure.Application.Abstract;
using ProductionStructure.Application.ConfigurationData.Units.Commands.UpdateUnit;
using ProductionStructure.Contracts.ConfigurationData;
using ProductionStructure.Contracts.HistoricalData;
using ProductionStructure.Domain.Entity.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionStructure.Application.ConfigurationData.Units.Commands.UpdateUnit
{
    public class UpdateUnitCommandHandler : ICommandHandler<UpdateUnitCommand>
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUnitCommandHandler(IUnitRepository unitRepository, IUnitOfWork unitOfWork)
        {
            _unitRepository = unitRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(UpdateUnitCommand request, CancellationToken cancellationToken)
        {
            _unitRepository.UpdateUnit(request.Unit);
            _unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
