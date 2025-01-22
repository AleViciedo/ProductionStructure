using AutoMapper;
using ProductionStructure.Domain.Entity.HistoricalData;
using ProductionStructure.GrpcProtos;

namespace ProductionStructure.GrpcServices.Mappers.HistoricalData
{
    public class WorkSessionProfile : Profile
    {
        public WorkSessionProfile()
        {
            CreateMap<Domain.Entity.HistoricalData.WorkSession, WorkSessionDTO> ()
                .ForMember(dto => dto.Id, o => o.MapFrom(ws => ws.Id))
                .ForMember(dto => dto.Initdate, o => o.MapFrom(ws => ws.InitDate))
                .ForMember(dto => dto.Unit, o => o.MapFrom(ws => ws.Unit))
                .ForMember(dto => dto.Enddate, o => o.MapFrom(ws => ws.EndDate))
                .ForMember(dto => dto.Unitid, o => o.MapFrom(ws => ws.UnitId));

            CreateMap<WorkSessionDTO, Domain.Entity.HistoricalData.WorkSession>()
                .ForMember(ws => ws.Id, o => o.MapFrom(dto => dto.Id))
                .ForMember(ws => ws.InitDate, o => o.MapFrom(dto => dto.Initdate))
                .ForMember(ws => ws.EndDate, o => o.MapFrom(dto => dto.Enddate))
                .ForMember(ws => ws.Unit, o => o.MapFrom(dto => dto.Unit))
                .ForMember(ws => ws.UnitId, o => o.MapFrom(dto => dto.Unitid));
        }
    }
}
