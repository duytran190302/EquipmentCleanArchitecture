using AutoMapper;
using EquipmentManagement.Application.Feature.Location.Commands.CreateLocation;
using EquipmentManagement.Application.Feature.Location.Queries.GetAllLocations;
using EquipmentManagement.Domain;

namespace EquipmentManagement.Application.MappingProfile
{
	public class LocationProfile : Profile
	{
        public LocationProfile()
        {
            CreateMap<Location, LocationDTO>().ReverseMap();
            CreateMap<CreateLocation, Location>();
        }
    }



}
