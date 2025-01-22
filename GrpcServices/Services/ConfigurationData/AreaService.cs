using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using ProductionStructure.Contracts;
using ProductionStructure.Contracts.ConfigurationData;
using ProductionStructure.Contracts.HistoricalData;
using ProductionStructure.GrpcProtos;

namespace ProductionStructure.GrpcServices.Services.ConfigurationData
{
    public class AreaService : Area.AreaBase
    {
        private readonly IAreaRepository _areaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AreaService(
            IAreaRepository areaRepository,
            IUnitOfWork unitOfWork)
        {
            _areaRepository = areaRepository;
            _unitOfWork = unitOfWork;
        }
        public override Task<AreaDTO> CreateArea(CreateAreaRequest request, ServerCallContext context)
        {
            return base.CreateArea(request, context);
        }

        public override Task<Empty> DeleteArea(DeleteRequest request, ServerCallContext context)
        {
            return base.DeleteArea(request, context);
        }

        public override Task<Areas> GetAllAreas(Empty request, ServerCallContext context)
        {
            return base.GetAllAreas(request, context);
        }

        public override Task<NullableAreaDTO> GetArea(GetRequest request, ServerCallContext context)
        {
            return base.GetArea(request, context);
        }

        public override Task<Empty> UpdateArea(AreaDTO request, ServerCallContext context)
        {
            return base.UpdateArea(request, context);
        }
    }
}
