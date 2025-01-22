using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using ProductionStructure.Contracts;
using ProductionStructure.Contracts.HistoricalData;
using ProductionStructure.GrpcProtos;
using System.Net.NetworkInformation;

namespace ProductionStructure.GrpcServices.Services.HistoricalData
{
    public class WorkSessionService : WorkSession.WorkSessionBase
    {
        private readonly IWorkSessionRepository _workSessionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public WorkSessionService(
            IWorkSessionRepository workSessionRepository,
            IUnitOfWork unitOfWork)
        {
            _workSessionRepository = workSessionRepository;
            _unitOfWork = unitOfWork;
        }
        public override Task<WorkSessionDTO> CreateWorkSession(CreateWorkSessionRequest request, ServerCallContext context)
        {
            return base.CreateWorkSession(request, context);
        }

        public override Task<Empty> DeleteWorkSession(DeleteRequest request, ServerCallContext context)
        {
            return base.DeleteWorkSession(request, context);
        }

        public override Task<WorkSessions> GetAllWorkSessions(Empty request, ServerCallContext context)
        {
            return base.GetAllWorkSessions(request, context);
        }

        public override Task<NullableWorkSessionDTO> GetWorkSession(GetRequest request, ServerCallContext context)
        {
            return base.GetWorkSession(request, context);
        }

        public override Task<Empty> UpdateWorkSession(WorkSessionDTO request, ServerCallContext context)
        {
            return base.UpdateWorkSession(request, context);
        }
    }
}
