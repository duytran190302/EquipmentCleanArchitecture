using AutoMapper;
using EquipmentManagement.Application.Feature.Picture.Commands.CreatePicture;
using EquipmentManagement.Application.Feature.Picture.Queries.GetPicture;
using EquipmentManagement.Application.Feature.Specification.Commands.CreateSpec;
using EquipmentManagement.Application.Feature.Specification.Queries.GetSpec;
using EquipmentManagement.Domain;

namespace EquipmentManagement.Application.MappingProfile
{
	public class PictureProfile : Profile
	{
        public PictureProfile()
        {
			CreateMap<Picture, PictureDTO>().ReverseMap();
			CreateMap<CreatePicture, Picture>();
		}
    }



}
