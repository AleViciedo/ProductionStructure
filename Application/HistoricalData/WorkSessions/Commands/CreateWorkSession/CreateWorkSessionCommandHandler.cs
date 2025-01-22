using ProductionStructure.Application.Abstract;
using ProductionStructure.Contracts;
using ProductionStructure.Contracts.HistoricalData;
using ProductionStructure.Domain.Entity.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionStructure.Application.HistoricalData.WorkSessions.Commands.CreateWorkSession
{
    public class CreateWorkSessionCommandHandler : ICommandHandler<CreateWorkSessionCommand, WorkSession>
    {
        private readonly IWorkSessionRepository _workSessionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateWorkSessionCommandHandler(IWorkSessionRepository workSessionRepository, IUnitOfWork unitOfWork)
        {
            _workSessionRepository = workSessionRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<WorkSession> Handle(CreateWorkSessionCommand request, CancellationToken cancellationToken)
        {
            WorkSession result = new WorkSession(request.Unit, request.InitDate);
            _workSessionRepository.AddWorkSession(result);
            _unitOfWork.SaveChanges();

            return Task.FromResult(result);
        }
    }
}
