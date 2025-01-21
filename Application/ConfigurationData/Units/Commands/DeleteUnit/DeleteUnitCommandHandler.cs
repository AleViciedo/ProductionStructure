using Contracts;
using ProductionStructure.Application.Abstract;
using ProductionStructure.Application.ConfigurationData.Units.Commands.DeleteWorkCenter;
using ProductionStructure.Contracts.ConfigurationData;
using ProductionStructure.Contracts.HistoricalData;
using ProductionStructure.Domain.Entity.ConfigurationData;
using ProductionStructure.Domain.Entity.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionStructure.Application.ConfigurationData.Units.Commands.DeleteUnit
{
    public class DeleteUnitCommandHandler : ICommandHandler<DeleteUnitCommand>
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUnitCommandHandler(IUnitRepository unitRepository, IUnitOfWork unitOfWork)
        {
            _unitRepository = unitRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(DeleteUnitCommand request, CancellationToken cancellationToken)
        {
            Unit? unit = _unitRepository.GetUnitById(request.Id);
            if (unit is null)
            {
                return Task.CompletedTask;
            }
            _unitRepository.DeleteUnit(unit);
            _unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
