using AutoMapper;
using ProductionStructure.GrpcProtos;

namespace ProductionStructure.GrpcServices.Mappers.ConfigurationData
{
    public class AreaProfile : Profile
    {
        public AreaProfile()
        {
            CreateMap<Domain.Entity.ConfigurationData.Area, AreaDTO>()
                .ForMember(dto => dto.Id, o => o.MapFrom(a => a.Id))
                .ForMember(dto => dto.Name, o => o.MapFrom(a => a.Name))
                .ForMember(dto => dto.Workcenters, o => o.MapFrom(a => a.WorkCenters))
                .ForMember(dto => dto.Site, o => o.MapFrom(a => a.Site))
                .ForMember(dto => dto.Siteid, o => o.MapFrom(a => a.SiteId));

            CreateMap<AreaDTO, Domain.Entity.ConfigurationData.Area>()
                .ForMember(a => a.Id, o => o.MapFrom(dto => dto.Id))
                .ForMember(a => a.Name, o => o.MapFrom(dto => dto.Name))
                .ForMember(a => a.WorkCenters, o => o.MapFrom(dto => dto.Workcenters))
                .ForMember(a => a.Site, o => o.MapFrom(dto => dto.Site))
                .ForMember(a => a.SiteId, o => o.MapFrom(dto => dto.Siteid));
        }
    }
}
