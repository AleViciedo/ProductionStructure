using Contracts;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using ProductionStructure.Contracts.HistoricalData;
using ProductionStructure.GrpcProtos;

namespace ProductionStructure.GrpcServices.Services.ConfigurationData
{
    public class WorkCenterService : WorkCenter.WorkCenterBase
    {
        private readonly IWorkCenterRepository _workCenterRepository;
        private readonly IUnitOfWork _unitOfWork;

        public WorkCenterService(
            IWorkCenterRepository workCenterRepository,
            IUnitOfWork unitOfWork)
        {
            _workCenterRepository = workCenterRepository;
            _unitOfWork = unitOfWork;
        }
        public override Task<WorkCenterDTO> CreateWorkCenter(CreateWorkCenterRequest request, ServerCallContext context)
        {
            return base.CreateWorkCenter(request, context);
        }

        public override Task<Empty> DeleteWorkCenter(DeleteRequest request, ServerCallContext context)
        {
            return base.DeleteWorkCenter(request, context);
        }

        public override Task<WorkCenters> GetAllWorkCenters(Empty request, ServerCallContext context)
        {
            return base.GetAllWorkCenters(request, context);
        }

        public override Task<NullableWorkCenterDTO> GetWorkCenter(GetRequest request, ServerCallContext context)
        {
            return base.GetWorkCenter(request, context);
        }

        public override Task<Empty> UpdateWorkCenter(WorkCenterDTO request, ServerCallContext context)
        {
            return base.UpdateWorkCenter(request, context);
        }
    }
}
