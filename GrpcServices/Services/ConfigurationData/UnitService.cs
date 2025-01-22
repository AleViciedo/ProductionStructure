
using AutoMapper;
using Contracts;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MediatR;
using ProductionStructure.Application.ConfigurationData.Units.Commands.CreateWorkCenter;
using ProductionStructure.Application.ConfigurationData.Units.Commands.DeleteWorkCenter;
using ProductionStructure.Application.ConfigurationData.Units.Commands.UpdateUnit;
using ProductionStructure.Application.ConfigurationData.Units.Queries.GetAllUnits;
using ProductionStructure.Application.ConfigurationData.Units.Queries.GetUnitById;
using ProductionStructure.Contracts.ConfigurationData;
using ProductionStructure.Contracts.HistoricalData;
using ProductionStructure.GrpcProtos;

namespace ProductionStructure.GrpcServices.Services.ConfigurationData
{
    public class UnitService : GrpcProtos.Unit.UnitBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UnitService(
            IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        public override Task<UnitDTO> CreateUnit(CreateUnitRequest request, ServerCallContext context)
        {
            var command = new CreateUnitCommand(
                request.Name,
                _mapper.Map<Domain.Entity.ConfigurationData.WorkCenter>(request.Workcenter));

            var result = _mediator.Send(command).Result;

            return Task.FromResult(_mapper.Map<UnitDTO>(result));
        }

        public override Task<Empty> DeleteUnit(DeleteRequest request, ServerCallContext context)
        {
            var command = new DeleteUnitCommand(System.Guid.Parse(request.Id));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }

        public override Task<Units> GetAllUnits(Empty request, ServerCallContext context)
        {
            var command = new GetAllUnitsQuery();

            var result = _mediator.Send(command).Result;

            return Task.FromResult(_mapper.Map<Units>(result));
        }

        public override Task<NullableUnitDTO> GetUnitById(GetRequest request, ServerCallContext context)
        {
            var command = new GetUnitByIdQuery(System.Guid.Parse(request.Id));

            var result = _mediator.Send(command).Result;

            return Task.FromResult(_mapper.Map<NullableUnitDTO>(result));
        }

        public override Task<Empty> UpdateUnit(UnitDTO request, ServerCallContext context)
        {
            var command = new UpdateUnitCommand(_mapper.Map<Domain.Entity.ConfigurationData.Unit>(request));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }
    }
}
