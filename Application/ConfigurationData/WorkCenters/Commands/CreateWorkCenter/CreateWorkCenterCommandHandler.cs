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

namespace ProductionStructure.Application.ConfigurationData.WorkCenters.Commands.CreateWorkCenter
{
    public class CreateWorkCenterCommandHandler : ICommandHandler<CreateWorkCenterCommand, WorkCenter>
    {
        private readonly IWorkCenterRepository _workCenterRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateWorkCenterCommandHandler(IWorkCenterRepository workCenterRepository, IUnitOfWork unitOfWork)
        {
            _workCenterRepository = workCenterRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<WorkCenter> Handle(CreateWorkCenterCommand request, CancellationToken cancellationToken)
        {
            WorkCenter result = new WorkCenter(request.Name, request.Area);
            _workCenterRepository.AddWorkCenter(result);
            _unitOfWork.SaveChanges();

            return Task.FromResult(result);
        }
    }
}
