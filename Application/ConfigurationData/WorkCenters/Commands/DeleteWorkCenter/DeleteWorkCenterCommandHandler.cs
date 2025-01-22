using ProductionStructure.Application.Abstract;
using ProductionStructure.Application.ConfigurationData.WorkCenters.Commands.DeleteWorkCenter;
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

namespace ProductionStructure.Application.ConfigurationData.WorkCenters.Commands.DeleteWorkCenter
{
    public class DeleteWorkCenterCommandHandler : ICommandHandler<DeleteWorkCenterCommand>
    {
        private readonly IWorkCenterRepository _workCenterRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteWorkCenterCommandHandler(IWorkCenterRepository workCenterRepository, IUnitOfWork unitOfWork)
        {
            _workCenterRepository = workCenterRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(DeleteWorkCenterCommand request, CancellationToken cancellationToken)
        {
            WorkCenter? workCenter = _workCenterRepository.GetWorkCenterById(request.Id);
            if (workCenter is null)
            {
                return Task.CompletedTask;
            }
            _workCenterRepository.DeleteWorkCenter(workCenter);
            _unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
