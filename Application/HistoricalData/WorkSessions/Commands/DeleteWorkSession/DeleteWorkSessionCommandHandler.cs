using Contracts;
using ProductionStructure.Application.Abstract;
using ProductionStructure.Application.HistoricalData.WorkSessions.Commands.UpdateWorkSession;
using ProductionStructure.Contracts.HistoricalData;
using ProductionStructure.Domain.Entity.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionStructure.Application.HistoricalData.WorkSessions.Commands.DeleteWorkSession
{
    public class DeleteWorkSessionCommandHandler : ICommandHandler<DeleteWorkSessionCommand>
    {
        private readonly IWorkSessionRepository _workSessionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteWorkSessionCommandHandler(IWorkSessionRepository workSessionRepository, IUnitOfWork unitOfWork)
        {
            _workSessionRepository = workSessionRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(DeleteWorkSessionCommand request, CancellationToken cancellationToken)
        {
            WorkSession? workSession = _workSessionRepository.GetWorkSessionById(request.Id);
            if (workSession is null)
            {
                return Task.CompletedTask;
            }
            _workSessionRepository.DeleteWorkSession(workSession);
            _unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
