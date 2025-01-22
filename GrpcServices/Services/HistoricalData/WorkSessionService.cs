using AutoMapper;
using Contracts;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MediatR;
using ProductionStructure.Application.ConfigurationData.WorkCenters.Commands.CreateWorkCenter;
using ProductionStructure.Application.HistoricalData.WorkSessions.Commands.CreateWorkSession;
using ProductionStructure.Application.HistoricalData.WorkSessions.Commands.DeleteWorkSession;
using ProductionStructure.Application.HistoricalData.WorkSessions.Commands.UpdateWorkSession;
using ProductionStructure.Application.HistoricalData.WorkSessions.Queries.GetAllWorkSessions;
using ProductionStructure.Application.HistoricalData.WorkSessions.Queries.GetWorkSessionById;
using ProductionStructure.Contracts.HistoricalData;
using ProductionStructure.GrpcProtos;
using System.Net.NetworkInformation;

namespace ProductionStructure.GrpcServices.Services.HistoricalData
{
    public class WorkSessionService : WorkSession.WorkSessionBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public WorkSessionService(
            IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        public override Task<WorkSessionDTO> CreateWorkSession(CreateWorkSessionRequest request, ServerCallContext context)
        {
            var command = new CreateWorkSessionCommand(
                request.Initdate.ToDateTime(),
                _mapper.Map<Domain.Entity.ConfigurationData.Unit>(request.Unit));

            var result = _mediator.Send(command).Result;

            return Task.FromResult(_mapper.Map<WorkSessionDTO>(result));
        }

        public override Task<Empty> DeleteWorkSession(DeleteRequest request, ServerCallContext context)
        {
            var command = new DeleteWorkSessionCommand(System.Guid.Parse(request.Id));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }

        public override Task<WorkSessions> GetAllWorkSessions(Empty request, ServerCallContext context)
        {
            var command = new GetAllWorkSessionsQuery();

            var result = _mediator.Send(command).Result;

            return Task.FromResult(_mapper.Map<WorkSessions>(result));
        }

        public override Task<NullableWorkSessionDTO> GetWorkSessionById(GetRequest request, ServerCallContext context)
        {
            var command = new GetWorkSessionByIdQuery(System.Guid.Parse(request.Id));

            var result = _mediator.Send(command).Result;

            return Task.FromResult(_mapper.Map<NullableWorkSessionDTO>(result));
        }

        public override Task<Empty> UpdateWorkSession(WorkSessionDTO request, ServerCallContext context)
        {
            var command = new UpdateWorkSessionCommand(_mapper.Map<Domain.Entity.HistoricalData.WorkSession>(request));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }
    }
}
