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
using ProductionStructure.Application.ConfigurationData.WorkCenters.Commands.CreateWorkCenter;
using ProductionStructure.Application.ConfigurationData.WorkCenters.Commands.DeleteWorkCenter;
using ProductionStructure.Application.ConfigurationData.WorkCenters.Commands.UpdateWorkCenter;
using ProductionStructure.Application.ConfigurationData.WorkCenters.Queries.GetAllWorkCenters;
using ProductionStructure.Application.ConfigurationData.WorkCenters.Queries.GetWorkCenterById;
using ProductionStructure.Contracts.HistoricalData;
using ProductionStructure.GrpcProtos;

namespace ProductionStructure.GrpcServices.Services.ConfigurationData
{
    public class WorkCenterService : WorkCenter.WorkCenterBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public WorkCenterService(
            IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        public override Task<WorkCenterDTO> CreateWorkCenter(CreateWorkCenterRequest request, ServerCallContext context)
        {
            var command = new CreateWorkCenterCommand(
                request.Name,
                _mapper.Map<Domain.Entity.ConfigurationData.Area>(request.Area));

            var result = _mediator.Send(command).Result;

            return Task.FromResult(_mapper.Map<WorkCenterDTO>(result));
        }

        public override Task<Empty> DeleteWorkCenter(DeleteRequest request, ServerCallContext context)
        {
            var command = new DeleteWorkCenterCommand(System.Guid.Parse(request.Id));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }

        public override Task<WorkCenters> GetAllWorkCenters(Empty request, ServerCallContext context)
        {
            var command = new GetAllWorkCentersQuery();

            var result = _mediator.Send(command).Result;

            return Task.FromResult(_mapper.Map<WorkCenters>(result));
        }

        public override Task<NullableWorkCenterDTO> GetWorkCenterById(GetRequest request, ServerCallContext context)
        {
            var command = new GetWorkCenterByIdQuery(System.Guid.Parse(request.Id));

            var result = _mediator.Send(command).Result;

            return Task.FromResult(_mapper.Map<NullableWorkCenterDTO>(result));
        }

        public override Task<Empty> UpdateWorkCenter(WorkCenterDTO request, ServerCallContext context)
        {
            var command = new UpdateWorkCenterCommand(_mapper.Map<Domain.Entity.ConfigurationData.WorkCenter>(request));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }
    }
}
