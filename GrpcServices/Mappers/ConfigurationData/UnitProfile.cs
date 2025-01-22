using AutoMapper;
using ProductionStructure.GrpcProtos;

namespace ProductionStructure.GrpcServices.Mappers.ConfigurationData
{
    public class UnitProfile : Profile
    {
        public UnitProfile()
        {
            CreateMap<Domain.Entity.ConfigurationData.Unit, UnitDTO>()
                .ForMember(dto => dto.Id, o => o.MapFrom(u => u.Id))
                .ForMember(dto => dto.Name, o => o.MapFrom(u => u.Name))
                .ForMember(dto => dto.Manufacturer, o => o.MapFrom(u => u.Manufacturer))
                .ForMember(dto => dto.Description, o => o.MapFrom(u => u.Description))
                .ForMember(dto => dto.Currentworksession, o => o.MapFrom(u => u.CurrentWorkSession))
                .ForMember(dto => dto.Currentworksessionid, o => o.MapFrom(u => u.CurrentWorkSessionId))
                .ForMember(dto => dto.Worksessions, o => o.MapFrom(u => u.WorkSessions))
                .ForMember(dto => dto.Inuse, o => o.MapFrom(u => u.InUse))
                .ForMember(dto => dto.Workcenter, o => o.MapFrom(u => u.WorkCenter))
                .ForMember(dto => dto.Workcenterid, o => o.MapFrom(u => u.WorkCenterId));

            CreateMap<UnitDTO, Domain.Entity.ConfigurationData.Unit>()
                .ForMember(u => u.Id, o => o.MapFrom(dto => dto.Id))
                .ForMember(u => u.Name, o => o.MapFrom(dto => dto.Name))
                .ForMember(u => u.Manufacturer, o => o.MapFrom(dto => dto.Manufacturer))
                .ForMember(u => u.Description, o => o.MapFrom(dto => dto.Description))
                .ForMember(u => u.CurrentWorkSession, o => o.MapFrom(dto => dto.Currentworksession))
                .ForMember(u => u.CurrentWorkSessionId, o => o.MapFrom(dto => dto.Currentworksessionid))
                .ForMember(u => u.WorkSessions, o => o.MapFrom(dto => dto.Worksessions))
                .ForMember(u => u.InUse, o => o.MapFrom(dto => dto.Inuse))
                .ForMember(u => u.WorkCenter, o => o.MapFrom(dto => dto.Workcenter))
                .ForMember(u => u.WorkCenterId, o => o.MapFrom(dto => dto.Workcenterid));

        }
    }
}
