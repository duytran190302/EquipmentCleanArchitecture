using AutoMapper;
using EquipmentManagement.Application.Feature.Location.Commands.CreateLocation;
using EquipmentManagement.Application.Feature.Location.Commands.UpdateLocation;
using EquipmentManagement.Application.Feature.Location.Queries.GetAllLocations;
using EquipmentManagement.Application.Feature.Tag.Commands.CreateTag;
using EquipmentManagement.Application.Feature.Tag.Commands.UpdateTag;
using EquipmentManagement.Application.Feature.Tag.Queries.GetAllTag;
using EquipmentManagement.Domain;

namespace EquipmentManagement.Application.MappingProfile
{
	public class TagProfile : Profile
	{
        public TagProfile()
        {
			CreateMap<Tag, TagDTO>().ReverseMap();
			CreateMap<CreateTag, Tag>();
			CreateMap<UpdateTag, Tag>();

		}
    }



}
