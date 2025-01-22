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

namespace ProductionStructure.Application.ConfigurationData.Units.Commands.CreateUnit
{
    public class CreateUnitCommandHandler : ICommandHandler<CreateUnitCommand, Unit>
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUnitCommandHandler(IUnitRepository unitRepository, IUnitOfWork unitOfWork)
        {
            _unitRepository = unitRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<Unit> Handle(CreateUnitCommand request, CancellationToken cancellationToken)
        {
            Unit result = new Unit(request.Name, request.WorkCenter);
            _unitRepository.AddUnit(result);
            _unitOfWork.SaveChanges();

            return Task.FromResult(result);
        }
    }
}
