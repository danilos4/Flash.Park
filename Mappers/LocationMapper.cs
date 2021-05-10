using AutoMapper;
using Flash.Park.Data;

namespace Flash.Park.Mappers
{
    public class LocationMapper : Profile
    {
        public LocationMapper()
        {
            CreateMap<Location, LocationDto>()
                .ForMember(d => d.Floors, opts => opts.MapFrom(s => s.Floor));

            CreateMap<Floor, FloorDto>();
        }
    }
}
