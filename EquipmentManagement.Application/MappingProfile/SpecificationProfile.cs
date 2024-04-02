using AutoMapper;
using EquipmentManagement.Application.Feature.Specification.Commands.CreateSpec;
using EquipmentManagement.Application.Feature.Specification.Queries.GetSpec;
using EquipmentManagement.Application.Feature.Supplier.Commands.CreateSupplier;
using EquipmentManagement.Application.Feature.Supplier.Queries.GetAllSupplier;
using EquipmentManagement.Domain;

namespace EquipmentManagement.Application.MappingProfile
{
	public class SpecificationProfile : Profile
	{
        public SpecificationProfile()
        {
			CreateMap<Specification, SpecDTO>().ReverseMap();
			CreateMap<CreateSpec, Specification>();
		}
    }



}
