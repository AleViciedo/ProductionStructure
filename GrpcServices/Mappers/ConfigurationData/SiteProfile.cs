using AutoMapper;
using ProductionStructure.GrpcProtos;

namespace ProductionStructure.GrpcServices.Mappers.ConfigurationData
{
    public class SiteProfile : Profile
    {
        public SiteProfile()
        {
            CreateMap<Domain.Entity.ConfigurationData.Site, SiteDTO>()
                .ForMember(dto => dto.Id, o => o.MapFrom(s => s.Id))
                .ForMember(dto => dto.Name, o => o.MapFrom(s => s.Name))
                .ForMember(dto => dto.Location, o => o.MapFrom(s => s.Location))
                .ForMember(dto => dto.Email, o => o.MapFrom(s => s.Email))
                .ForMember(dto => dto.Phonenumber, o => o.MapFrom(s => s.PhoneNumber))
                .ForMember(dto => dto.Areas, o => o.MapFrom(s => s.Areas));

            CreateMap<SiteDTO, Domain.Entity.ConfigurationData.Site>()
                .ForMember(s => s.Id, o => o.MapFrom(dto => dto.Id))
                .ForMember(s => s.Name, o => o.MapFrom(dto => dto.Name))
                .ForMember(s => s.Location, o => o.MapFrom(dto => dto.Location))
                .ForMember(s => s.Email, o => o.MapFrom(dto => dto.Email))
                .ForMember(s => s.PhoneNumber, o => o.MapFrom(dto => dto.Phonenumber))
                .ForMember(s => s.Areas, o => o.MapFrom(dto => dto.Areas));
        }
    }
}
