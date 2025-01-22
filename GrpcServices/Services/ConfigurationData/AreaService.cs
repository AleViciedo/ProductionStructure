using AutoMapper;
using Contracts;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MediatR;
using ProductionStructure.Application.ConfigurationData.Areas.Commands.CreateWorkCenter;
using ProductionStructure.Application.ConfigurationData.Areas.Commands.DeleteWorkCenter;
using ProductionStructure.Application.ConfigurationData.Areas.Commands.UpdateArea;
using ProductionStructure.Application.ConfigurationData.Areas.Queries.GetAllAreas;
using ProductionStructure.Application.ConfigurationData.Areas.Queries.GetAreaById;
using ProductionStructure.Application.ConfigurationData.WorkCenters.Commands.CreateWorkCenter;
using ProductionStructure.Application.ConfigurationData.WorkCenters.Commands.DeleteWorkCenter;
using ProductionStructure.Application.ConfigurationData.WorkCenters.Commands.UpdateWorkCenter;
using ProductionStructure.Application.ConfigurationData.WorkCenters.Queries.GetAllWorkCenters;
using ProductionStructure.Application.ConfigurationData.WorkCenters.Queries.GetWorkCenterById;
using ProductionStructure.Contracts.HistoricalData;
using ProductionStructure.GrpcProtos;

namespace ProductionStructure.GrpcServices.Services.ConfigurationData
{
    public class AreaService : Area.AreaBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AreaService(
            IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        public override Task<AreaDTO> CreateArea(CreateAreaRequest request, ServerCallContext context)
        {
            var command = new CreateAreaCommand(
                request.Name,
                _mapper.Map<Domain.Entity.ConfigurationData.Site>(request.Site));

            var result = _mediator.Send(command).Result;

            return Task.FromResult(_mapper.Map<AreaDTO>(result));
        }

        public override Task<Empty> DeleteArea(DeleteRequest request, ServerCallContext context)
        {
            var command = new DeleteAreaCommand(System.Guid.Parse(request.Id));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }

        public override Task<Areas> GetAllAreas(Empty request, ServerCallContext context)
        {
            var command = new GetAllAreasQuery();

            var result = _mediator.Send(command).Result;

            return Task.FromResult(_mapper.Map<Areas>(result));
        }

        public override Task<NullableAreaDTO> GetAreaById(GetRequest request, ServerCallContext context)
        {
            var command = new GetAreaByIdQuery(System.Guid.Parse(request.Id));

            var result = _mediator.Send(command).Result;

            return Task.FromResult(_mapper.Map<NullableAreaDTO>(result));
        }

        public override Task<Empty> UpdateArea(AreaDTO request, ServerCallContext context)
        {
            var command = new UpdateAreaCommand(_mapper.Map<Domain.Entity.ConfigurationData.Area>(request));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }
    }
}
