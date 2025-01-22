using ProductionStructure.Application.Abstract;
using ProductionStructure.Application.ConfigurationData.WorkCenters.Commands.UpdateWorkCenter;
using ProductionStructure.Contracts;
using ProductionStructure.Contracts.ConfigurationData;
using ProductionStructure.Contracts.HistoricalData;
using ProductionStructure.Domain.Entity.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionStructure.Application.ConfigurationData.WorkCenters.Commands.UpdateWorkCenter
{
    public class UpdateWorkCenterCommandHandler : ICommandHandler<UpdateWorkCenterCommand>
    {
        private readonly IWorkCenterRepository _workCenterRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateWorkCenterCommandHandler(IWorkCenterRepository workCenterRepository, IUnitOfWork unitOfWork)
        {
            _workCenterRepository = workCenterRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(UpdateWorkCenterCommand request, CancellationToken cancellationToken)
        {
            _workCenterRepository.UpdateWorkCenter(request.WorkCenter);
            _unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
