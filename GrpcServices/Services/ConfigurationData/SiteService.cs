using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using ProductionStructure.Contracts;
using ProductionStructure.Contracts.ConfigurationData;
using ProductionStructure.Contracts.HistoricalData;
using ProductionStructure.GrpcProtos;

namespace ProductionStructure.GrpcServices.Services.ConfigurationData
{
    public class SiteService : Site.SiteBase
    {
        private readonly ISiteRepository _siteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SiteService(
            ISiteRepository siteRepository,
            IUnitOfWork unitOfWork)
        {
            _siteRepository = siteRepository;
            _unitOfWork = unitOfWork;
        }
        public override Task<SiteDTO> CreateSite(CreateSiteRequest request, ServerCallContext context)
        {
            return base.CreateSite(request, context);
        }

        public override Task<Empty> DeleteSite(DeleteRequest request, ServerCallContext context)
        {
            return base.DeleteSite(request, context);
        }

        public override Task<Sites> GetAllSites(Empty request, ServerCallContext context)
        {
            return base.GetAllSites(request, context);
        }

        public override Task<NullableSiteDTO> GetSite(GetRequest request, ServerCallContext context)
        {
            return base.GetSite(request, context);
        }

        public override Task<Empty> UpdateSite(SiteDTO request, ServerCallContext context)
        {
            return base.UpdateSite(request, context);
        }
    }
}
