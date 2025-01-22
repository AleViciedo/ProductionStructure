using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using ProductionStructure.Contracts;
using ProductionStructure.Contracts.ConfigurationData;
using ProductionStructure.Contracts.HistoricalData;
using ProductionStructure.GrpcProtos;

namespace ProductionStructure.GrpcServices.Services.ConfigurationData
{
    public class UnitService : Unit.UnitBase
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UnitService(
            IUnitRepository unitRepository,
            IUnitOfWork unitOfWork)
        {
            _unitRepository = unitRepository;
            _unitOfWork = unitOfWork;
        }
        public override Task<UnitDTO> CreateUnit(CreateUnitRequest request, ServerCallContext context)
        {
            return base.CreateUnit(request, context);
        }

        public override Task<Empty> DeleteUnit(DeleteRequest request, ServerCallContext context)
        {
            return base.DeleteUnit(request, context);
        }

        public override Task<Units> GetAllUnits(Empty request, ServerCallContext context)
        {
            return base.GetAllUnits(request, context);
        }

        public override Task<NullableUnitDTO> GetUnit(GetRequest request, ServerCallContext context)
        {
            return base.GetUnit(request, context);
        }

        public override Task<Empty> UpdateUnit(UnitDTO request, ServerCallContext context)
        {
            return base.UpdateUnit(request, context);
        }
    }
}
