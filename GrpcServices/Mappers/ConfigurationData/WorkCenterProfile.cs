using AutoMapper;
using ProductionStructure.GrpcProtos;

namespace ProductionStructure.GrpcServices.Mappers.ConfigurationData
{
    public class WorkCenterProfile : Profile
    {
        public WorkCenterProfile()
        {
            CreateMap<Domain.Entity.ConfigurationData.WorkCenter, WorkCenterDTO>()
                .ForMember(dto => dto.Id, o => o.MapFrom(wc => wc.Id))
                .ForMember(dto => dto.Name, o => o.MapFrom(wc => wc.Name))
                .ForMember(dto => dto.Description,o => o.MapFrom(wc => wc.Description))
                .ForMember(dto => dto.Workmode, o => o.MapFrom(wc => wc.WorkMode))
                .ForMember(dto => dto.Units, o => o.MapFrom(wc => wc.Units))
                .ForMember(dto => dto.Area, o => o.MapFrom(wc => wc.Area))
                .ForMember(dto => dto.Areaid, o => o.MapFrom(wc => wc.AreaId));

            CreateMap<WorkCenterDTO, Domain.Entity.ConfigurationData.WorkCenter>()
                .ForMember(wc => wc.Id, o => o.MapFrom(dto => dto.Id))
                .ForMember(wc => wc.Name, o => o.MapFrom(dto => dto.Name))
                .ForMember(wc => wc.Description, o => o.MapFrom(dto => dto.Description))
                .ForMember(wc => wc.WorkMode, o => o.MapFrom(dto => dto.Workmode))
                .ForMember(wc => wc.Units, o => o.MapFrom(dto => dto.Units))
                .ForMember(wc => wc.Area, o => o.MapFrom(dto => dto.Area))
                .ForMember(wc => wc.AreaId, o => o.MapFrom(dto => dto.Areaid));
        }
    }
}
