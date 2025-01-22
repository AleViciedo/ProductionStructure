using AutoMapper;
using Contracts;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MediatR;
using ProductionStructure.Application.ConfigurationData.Sites.Commands.CreateWorkCenter;
using ProductionStructure.Application.ConfigurationData.Sites.Commands.DeleteWorkCenter;
using ProductionStructure.Application.ConfigurationData.Sites.Commands.UpdateSite;
using ProductionStructure.Application.ConfigurationData.Sites.Queries.GetAllSites;
using ProductionStructure.Application.ConfigurationData.Sites.Queries.GetSiteById;
using ProductionStructure.Application.ConfigurationData.WorkCenters.Commands.CreateWorkCenter;
using ProductionStructure.Application.ConfigurationData.WorkCenters.Commands.DeleteWorkCenter;
using ProductionStructure.Application.ConfigurationData.WorkCenters.Commands.UpdateWorkCenter;
using ProductionStructure.Application.ConfigurationData.WorkCenters.Queries.GetAllWorkCenters;
using ProductionStructure.Application.ConfigurationData.WorkCenters.Queries.GetWorkCenterById;
using ProductionStructure.Contracts.ConfigurationData;
using ProductionStructure.Contracts.HistoricalData;
using ProductionStructure.GrpcProtos;

namespace ProductionStructure.GrpcServices.Services.ConfigurationData
{
    public class SiteService : Site.SiteBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public SiteService(
            IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        public override Task<SiteDTO> CreateSite(CreateSiteRequest request, ServerCallContext context)
        {
            var command = new CreateSiteCommand(
                request.Name,
                _mapper.Map<Domain.ValueObjects.Location>(request.Location));

            var result = _mediator.Send(command).Result;

            return Task.FromResult(_mapper.Map<SiteDTO>(result));
        }

        public override Task<Empty> DeleteSite(DeleteRequest request, ServerCallContext context)
        {
            var command = new DeleteSiteCommand(System.Guid.Parse(request.Id));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }

        public override Task<Sites> GetAllSites(Empty request, ServerCallContext context)
        {
            var command = new GetAllSitesQuery();

            var result = _mediator.Send(command).Result;

            return Task.FromResult(_mapper.Map<Sites>(result));
        }

        public override Task<NullableSiteDTO> GetSiteById(GetRequest request, ServerCallContext context)
        {
            var command = new GetSiteByIdQuery(System.Guid.Parse(request.Id));

            var result = _mediator.Send(command).Result;

            return Task.FromResult(_mapper.Map<NullableSiteDTO>(result));
        }

        public override Task<Empty> UpdateSite(SiteDTO request, ServerCallContext context)
        {
            var command = new UpdateSiteCommand(_mapper.Map<Domain.Entity.ConfigurationData.Site>(request));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }
    }
}
