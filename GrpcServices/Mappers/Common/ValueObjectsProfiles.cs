using AutoMapper;

namespace ProductionStructure.GrpcServices.Mappers.Common
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<GrpcProtos.Country, CountryData.Standard.Country>()
                .ForMember(dto => dto.CountryName, o => o.MapFrom(c => c.CountryName))
                .ForMember(dto => dto.CountryShortCode, o => o.MapFrom(c => c.CountryShortCode))
                .ForMember(dto => dto.PhoneCode, o => o.MapFrom(c => c.PhoneCode));

            CreateMap<CountryData.Standard.Country, GrpcProtos.Country>()
                .ForMember(c => c.CountryName, o => o.MapFrom(dto => dto.CountryName))
                .ForMember(c => c.CountryShortCode, o => o.MapFrom(dto => dto.CountryShortCode))
                .ForMember(c => c.PhoneCode, o => o.MapFrom(dto => dto.PhoneCode));
        }
    }

    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            CreateMap<GrpcProtos.Location, Domain.ValueObjects.Location>()
                .ForMember(dto => dto.Country, o => o.MapFrom(l => l.Country))
                .ForMember(dto => dto.City, o => o.MapFrom(l => l.City))
                .ForMember(dto => dto.Address, o => o.MapFrom(l => l.Address));

            CreateMap<Domain.ValueObjects.Location, GrpcProtos.Location>()
                .ForMember(l => l.Country, o => o.MapFrom(dto => dto.Country))
                .ForMember(l => l.City, o => o.MapFrom(dto => dto.City))
                .ForMember(l => l.Address, o => o.MapFrom(dto => dto.Address));
        }
    }
}
