using ProductionStructure.Application.Abstract;
using ProductionStructure.Application.HistoricalData.WorkSessions.Commands.CreateWorkSession;
using ProductionStructure.Contracts;
using ProductionStructure.Contracts.HistoricalData;
using ProductionStructure.Domain.Entity.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionStructure.Application.HistoricalData.WorkSessions.Commands.UpdateWorkSession
{
    public class UpdateWorkCenterCommandHandler : ICommandHandler<UpdateWorkSessionCommand>
    {
        private readonly IWorkSessionRepository _workSessionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateWorkCenterCommandHandler(IWorkSessionRepository workSessionRepository, IUnitOfWork unitOfWork)
        {
            _workSessionRepository = workSessionRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(UpdateWorkSessionCommand request, CancellationToken cancellationToken)
        {
            _workSessionRepository.UpdateWorkSession(request.WorkSession);
            _unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
